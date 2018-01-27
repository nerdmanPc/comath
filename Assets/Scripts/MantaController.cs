using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantaController : MonoBehaviour {

	[SerializeField] private float hp;
	[SerializeField] private float speed;
	[SerializeField] private bool isWild; 
	[SerializeField] private MantaBuff myBuff; 


	public MantaBuff getBuff(){
		return myBuff;
	}

	public void select(){
		/*TODO
		 * Ativa os controles na criatura
		 * Ativa a camera da criatura/centraliza a camera na criatura
		*/ 
	}

	void Start(){
		myBuff = new MantaBuff ();
		
	}

	void Update(){
		
	}


}
