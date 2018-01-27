using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb2D;
	// Use this for initialization
	void Start () {
		rb2D = this.gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void Moviment(){
		Vector2 horizontalMovement = Input.GetAxis ("Horizontal");
		if(){
			
		}
	}
}
//BRANCH
