using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterController : MonoBehaviour {

	public Rigidbody2D rb2D;
	public float speed;
	public bool isSelected = false; 

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isSelected){
			Moviment ();
			if (Input.GetKeyDown (KeyCode.W)) {
				//shoot()
			}
		}
	}

	void Moviment(){
		float horizontalMovement = Input.GetAxis ("Horizontal");

		rb2D.velocity =  new Vector2(horizontalMovement * speed, rb2D.velocity.y);
	}

	public void select(){
		isSelected = true;
	}

	public void deselect(){
		isSelected = false;
	}

	public void kill(){
		Destroy (this.gameObject);
	}
}
