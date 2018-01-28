using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour {

	public int totalHp = 100;
	public float speed;
	private int numJump = 2;
	private Rigidbody2D rb2D;
	public Transform FloorCenter;
	public Transform FloorLeft;
	public Transform FloorRight;
	public Camera camera;
	public float jumpHeight;
	public bool isSelected = true;

	private bool canDoubleJump = false;
	public bool mantaIsIn = false;
	public MantaController myManta = null;
	public GameObject mantaPrefab;

	void Start () {
		rb2D = this.gameObject.GetComponent<Rigidbody2D> ();
	}

	/*
	void OnTriggerStay2D(Collider2D other){
		
	}*/

	void Update(){
		Moviment ();
		Jump (); //processa jump
		Selector();
	}

	void OnTriggerStay2D(Collider2D trigger){
		if (Input.GetKeyDown(KeyCode.DownArrow)){
			if (trigger.attachedRigidbody.gameObject.CompareTag ("manta")) {
				getManta (trigger.attachedRigidbody.gameObject.GetComponent<MantaController>());
			}
		}
	}

	bool VerifyFloor(string layer){
		bool isFloorLeft = Physics2D.Linecast (this.transform.position, FloorLeft.position, 1 << LayerMask.NameToLayer(layer));
		bool isFloorRight = Physics2D.Linecast (this.transform.position, FloorRight.position, 1 << LayerMask.NameToLayer(layer));
		bool isFloorCenter = Physics2D.Linecast (this.transform.position, FloorCenter.position, 1 << LayerMask.NameToLayer(layer));
		bool isFloor = isFloorCenter || isFloorLeft || isFloorRight;
		return isFloor;
	}


	void Moviment(){

		float horizontalMovement = Input.GetAxis ("Horizontal");

		if (horizontalMovement != 0) {
			rb2D.velocity = new Vector2 (horizontalMovement * speed, rb2D.velocity.y);
		} else {
			rb2D.velocity = new Vector2 (0f, rb2D.velocity.y);
		}
	}

	void Jump(){

		//print (VerifyFloor("Platforms"));

		bool isFloor = VerifyFloor ("Platforms");

		if(Input.GetKeyDown(KeyCode.UpArrow) && (isFloor || (numJump > 0 && canDoubleJump))){

			rb2D.velocity = (Vector2.up * jumpHeight); 
			numJump = numJump - 1;
		}else if (isFloor) {
			//print ("resetou");
			numJump = 2;
		}
	}

	void Selector(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if (myManta != null)
				myManta.deselect ();
			this.isSelected = true;
			//TODO Câmera no Player
		}else if (Input.GetKeyDown (KeyCode.Alpha2) && (myManta != null || mantaIsIn)) {
			if (mantaIsIn) {
				releaseManta ();
			}
			this.isSelected = false;
			myManta.select();
			//TODO Câmera no Player
		}
	}


	public void getManta(MantaController manta){
		//TODO Animações
		recieveManta (manta);
	}

	public void recieveManta(MantaController manta){
		totalHp += 20;
		canDoubleJump = true;
		mantaIsIn = true;
		manta.kill ();
	}

	public void releaseManta(){
		totalHp -= 20;
		canDoubleJump = false;
		mantaIsIn = false;

		GameObject go = Instantiate(mantaPrefab, this.transform);
		myManta = go.GetComponent<MantaController> ();
	}

	//A ser chamado pela Manta
	public void loseManta(){
		isSelected = true;
		// TODO Camera Focus
		myManta = null;
	}
}