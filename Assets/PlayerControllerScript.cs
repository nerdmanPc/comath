using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {
	
	public float speed;
	[SerializeField] private CreatureBuff[5] buffs;

	private Rigidbody2D rb2D;

	public Transform FloorCenter;

	public Transform FloorLeft;

	public Transform FloorRight;

	public float jumpHeight;

	// Use this for initialization
	void Start () {
		rb2D = this.gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Moviment ();

	}

	void Update(){
		
		Jump ();

	}

	bool VerifyFloor(string layer){
		bool isFloorLeft = Physics2D.Linecast (this.transform.position, FloorLeft.position, 1 << LayerMask.NameToLayer(layer));

		bool isFloorRight = Physics2D.Linecast (this.transform.position, FloorRight.position, 1 << LayerMask.NameToLayer(layer));

		bool isFloorCenter = Physics2D.Linecast (this.transform.position, FloorCenter.position, 1 << LayerMask.NameToLayer(layer));

		bool isFloor = isFloorCenter || isFloorLeft || isFloorRight; ;

		return isFloor;
	}

	/*
	void Moviment(){
		
		float horizontalMovement = Input.GetAxis ("Horizontal");

		if (horizontalMovement != 0) {
			
			rb2D.velocity = new Vector2 (horizontalMovement * speed, rb2D.velocity.y);
		} else {

			rb2D.velocity = new Vector2 (0f, rb2D.velocity.y);

		}
	}

	void Jump(){

		print (VerifyFloor("Platforms"));

		bool isFloor = VerifyFloor ("Platforms");

		if(Input.GetKeyDown(KeyCode.UpArrow) && isFloor){
			
			rb2D.velocity = (Vector2.up * jumpHeight); 
		}

	}
*/
	void onTrggerStay(Collider other){
		CreatureBuff buff = other.gameObject.GetComponent<CreatureBuff> ();
		if (Input.GetAxisRaw ("Verical") < 0) {
			buff.attach (this);
		}
	}

	void addBuff (CreatureBuff buff){
		buffs [0] = buff;
	}
}
