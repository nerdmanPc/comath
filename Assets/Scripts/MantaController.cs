using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantaController : MonoBehaviour {

	[SerializeField] private float hp;
	[SerializeField] private float speed;
	[SerializeField] private MantaBuff myBuff; 
	[SerializeField] private bool isWild = true; 
	[SerializeField] private bool isSelected = false;

	[SerializeField] public GameObject prefab; //INICIALIZAR NO PREFAB
	[SerializeField] private TestPlayer player; //INICIALIZAR NO PREFAB

	/*
	public MantaController makeManta(Transform position){
		GameObject go =  Instantiate(prefab, position) as GameObject;
		return go.GetComponent<MantaController> ();
	}
	*/

	public void kill(){
		Destroy (this.gameObject);
	}

	public MantaBuff getBuff(){
		return myBuff;
	}

	public bool getIsWild(){ 
		return isWild; 
	}

	public void select(){
		isSelected = true; 
	}

	public void deselect(){
		isSelected = false;
	}

	public void suicide(){
		GameObject.Destroy (gameObject);
	}

	void Start(){
		myBuff = gameObject.GetComponent<MantaBuff> (); //chamar o construtor direto PODE DAR PROBLEMA; confirmar
	}

	void Update(){
		
	}
}
