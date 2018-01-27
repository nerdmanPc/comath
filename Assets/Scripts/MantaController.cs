using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantaController : MonoBehaviour {

	[SerializeField] private float hp;
	[SerializeField] private float speed;
	[SerializeField] private MantaBuff myBuff; 
	private bool isWild = true; 
	private bool isSelected = false;


	public MantaBuff getBuff(){
		return myBuff;
	}

	public void select(){
		isSelected = true; //TODO
	}

	public void deselect(){
		isSelected = false;
	}

	void Start(){
		myBuff = new MantaBuff (); //chamar o construtor direto PODE DAR PROBLEMA; confirmar
	}

	void Update(){
		
	}
}
