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
	//public Camera camera;
	public float jumpHeight;
	public bool isSelected = true;
	public Vector3 spawnOffset = new Vector3(0.5f, 0.0f, 0.0f);

	private bool canDoubleJump = false;
	public bool mantaIsIn = false;
	public MantaController myManta = null;
	public GameObject mantaPrefab;

	private bool canShoot = false;
	public bool spitterIsIn = false;
	public SpitterController mySpitter = null;
	public GameObject spitterPrefab;

	private bool canSmash = false;
	public bool atlasIsIn = false;
	public SpitterController myAtlas = null;
	public GameObject atlasPrefab; //SETAR NA UNITY

	void Start () {
		rb2D = this.gameObject.GetComponent<Rigidbody2D> ();
	}

	/*
	void OnTriggerStay2D(Collider2D other){
		
	}*/

	void Update(){
		if (isSelected){
			Moviment ();
			Jump (); //processa jump
		}
		Selector();
	}

	void OnTriggerStay2D(Collider2D trigger){
		if (Input.GetKeyDown(KeyCode.DownArrow) && isSelected){
			if (trigger.attachedRigidbody.gameObject.CompareTag ("manta")) {
				getManta (trigger.attachedRigidbody.gameObject.GetComponent<MantaController>());
			}else if (trigger.attachedRigidbody.gameObject.CompareTag ("spitter")) {
				getSpitter (trigger.attachedRigidbody.gameObject.GetComponent<SpitterController>());
			}else if (trigger.attachedRigidbody.gameObject.CompareTag ("atlas")) {
				getAtlas (trigger.attachedRigidbody.gameObject.GetComponent<AtlasController>());
			}
		}
	}



	//**** REVISEI ATÉ AQUI ***//

	void getAtlas (AtlasController atlas){
		return; //TODO
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
			if (horizontalMovement > 0) {
				spawnOffset = new Vector3 (0.5f, 0.0f, 0.0f);
			} else {
				spawnOffset = new Vector3 (-0.5f, 0.0f, 0.0f);
			}
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
			if (mySpitter != null) {
				mySpitter.deselect ();
			}
			this.isSelected = true;
			//TODO Câmera no Player
		}else if (Input.GetKeyDown (KeyCode.Alpha2) && (myManta != null || mantaIsIn)) {
			if (mantaIsIn) {
				releaseManta ();
			}
			this.isSelected = false;
			if (mySpitter != null) {
				mySpitter.deselect ();
			}
			myManta.select();
			//TODO Câmera no Player
		}else if (Input.GetKeyDown (KeyCode.Alpha3) && (mySpitter != null || spitterIsIn)) {
			if (spitterIsIn) {
				releaseSpitter ();
			}
			this.isSelected = false;
			if (myManta != null) {
				myManta.deselect ();
			}
			mySpitter.select();
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

		GameObject go = Instantiate(mantaPrefab, transform.position + spawnOffset, Quaternion.identity);
		myManta = go.GetComponent<MantaController> ();
	}

	//A ser chamado pela Manta
	public void loseManta(){
		isSelected = true;
		// TODO Camera Focus
		myManta = null;
	}

	public void getSpitter(SpitterController spitter){
		//TODO Animações
		recieveSpitter (spitter);
	}

	public void recieveSpitter(SpitterController spitter){
		totalHp += 20;
		canShoot = true;
		spitterIsIn = true;
		spitter.kill ();
	}

	public void releaseSpitter(){
		totalHp -= 20;
		canShoot = false;
		spitterIsIn = false;

		GameObject go = Instantiate(spitterPrefab, transform.position + spawnOffset, Quaternion.identity);
		mySpitter = go.GetComponent<SpitterController> ();
	}

	//A ser chamado pela spitter
	public void loseSpitter(){
		isSelected = true;
		// TODO Camera Focus
		mySpitter = null;
	}
}