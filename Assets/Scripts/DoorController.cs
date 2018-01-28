using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	private bool isOpen =  false;
	private bool atlasIsIn = false;
	private float timeToClose;
	public Collider2D doorCollider;
	public float timeOpen;


	// Use this for initialization
	void Start () {
		doorCollider = GetComponent<Collider2D> ();
	}

	public void open(){
		isOpen = true;
		timeToClose = Time.time + timeOpen;
		doorCollider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isOpen && Time.time > timeToClose && !atlasIsIn) {
			isOpen = false;
			doorCollider.isTrigger = false;
		}
	}
}
