using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtlasController : MonoBehaviour {

	public bool isSelected = false; 

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (isSelected && Input.GetKeyDown (KeyCode.E)) {
			//break()
		}
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
