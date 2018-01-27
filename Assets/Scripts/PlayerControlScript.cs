using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour {

	public float speed;

	public float jumpHeight;

	private Rigidbody2D rb; 

	public Transform FloorCenter;

	public Transform FloorLeft;

	public Transform FloorRight;

	public string playerNumber;

	//public GoalScript goal;

	private string jumpKey;

	private bool leftWall;

	private bool rightWall;

	private bool isOn;

	public Transform myDeathMarker;

	public Transform hisDeathMarker;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();	

		leftWall = false;

		rightWall = false;

		isOn = true;

		if (playerNumber == "1") {
			jumpKey = "w";
		} else {
			jumpKey = "up";
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if(isOn){
		    Movimentar ();

		    Pular ();

		    Mola ();
		}
	}

	/*void OnTriggerEnter2D ( Collider2D other){
		if (other.gameObject.tag == "Spike"){
			myDeathMarker.gameObject.SetActive (true);

			hisDeathMarker.gameObject.SetActive (true);

			isOn = false;

			Invoke ("Restart", 3f);
		} else if (other.gameObject.tag == "Goal"){
			goal.UpGoals();
		} else if (other.gameObject.tag == "LeftWall"){
			leftWall = true;
		} else if (other.gameObject.tag == "RightWall"){
			rightWall = true;
		}

	}

	void OnTriggerExit2D ( Collider2D other){
		if (other.gameObject.tag == "Goal"){
			goal.DownGoals();
		} else if (other.gameObject.tag == "LeftWall"){
			leftWall = false;
		} else if (other.gameObject.tag == "RightWall"){
			rightWall = false;
		}

	}*/

	void Restart(){
		Scene scene = SceneManager.GetActiveScene();

		SceneManager.LoadScene(scene.name);
	}

	void Movimentar()
	{
		float horizontal = Input.GetAxis ("Horizontal" + playerNumber);

		if ((horizontal > 0 && !leftWall) || (horizontal < 0 && !rightWall)){

		    Vector3 movement = new Vector3 (horizontal * speed * Time.deltaTime, 0f, 0f);

		    transform.Translate (movement);
		}
	}

	bool VerifyFloor(string layer){
		bool isFloorCenter = Physics2D.Linecast (this.transform.position, FloorCenter.position, 1 << LayerMask.NameToLayer (layer));

		bool isFloorLeft = Physics2D.Linecast (this.transform.position, FloorLeft.position, 1 << LayerMask.NameToLayer (layer));

		bool isFloorRight = Physics2D.Linecast (this.transform.position, FloorRight.position, 1 << LayerMask.NameToLayer (layer));

		bool isFloor = isFloorCenter || isFloorLeft || isFloorRight;

		return isFloor;
	}

	void Pular(){

		bool isFloor = VerifyFloor("Floor");

		if(Input.GetKeyDown(jumpKey) && isFloor){
			rb.velocity = (Vector2.up * jumpHeight) ;
		}
	}

	void Mola(){

		bool isFloor = VerifyFloor("Spring");

		if(isFloor){
			rb.velocity = (Vector2.up * 5f) ;
		}
	}
}
