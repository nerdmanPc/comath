using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

	public int totalHp;
	public float speed;
	private int numJump;
	private bool canDoubleJump;
	private bool isSelected;
	private CreatureBuff selectedBuff; 
	private Rigidbody2D rb2D;
	public Transform FloorCenter;
	public Transform FloorLeft;
	public Transform FloorRight;
	public float jumpHeight;
	public Pokedex myPokedex;

	// Use this for initialization
	void Start () {
		numJump = 2;
		totalHp = 100;
		rb2D = this.gameObject.GetComponent<Rigidbody2D> ();
		myPokedex = new Pokedex ();
		canDoubleJump = false;
	}

	// Update is called once per frame
	void FixedUpdate () {

		Moviment ();

	}

		
	public GameObject dummy;

	void Update(){

		Jump ();
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			assimilate (dummy.gameObject.GetComponent<MantaController>().getBuff());
		}
		if(Input.GetKeyDown(KeyCode.R)){
			detach (dummy.gameObject.GetComponent<MantaController>().getBuff());
		}

	}

	public void addTotalHp(int value){
		totalHp += value;
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

	public void select(){
		isSelected = true;
		CreatureBuff = null;
		/*TODO
		 * Ativa os controles no player
		 * Ativa a camera do player/centraliza a camera no player
		*/ 
	}

	public void deselect(){
		//TODO
	}

	public void assimilate(CreatureBuff buff){
		myPokedex.newPokemon (buff);  //Pode ser delegado ao Buff
		buff.attach (this);

	}



	public void setDJump(){
		canDoubleJump =! canDoubleJump;
	}

	public void shout(){
		print ("AAAAAAAAAAAAAAAHHHH");
	}

	public void detach(CreatureBuff buff){
		buff.detach (this);
	}

}