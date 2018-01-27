using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokedex : MonoBehaviour {
	[SerializeField] private CreatureBuff[] arrayBuff = new CreatureBuff[4];
	[SerializeField] private PlayerControllerScript player;
	private CreatureBuff selected; //se null, player selecionado


	private static Pokedex instance;

	/*
	private Pokedex(){
	}

	public static Pokedex setInstance(){
		if(instance == null)
			instance = new Pokedex();		
		return instance;
	}
	*/

	public void selector(int slotID){ //Mover a Câmera de acordo
		if (selected == null) {
			player.deselect ();
		} else {
			selected.deselect ();
		}
		if (slotID == 0) {
			selected = null;
			player.select ();
		} else {
			selected = arrayBuff [slotID - 1];
			selected.select ();
		}
	}


	// Use this for initialization
	void Start () {
		player = gameObject.GetComponent<PlayerControllerScript>();

	}

	/*Deve ser chamada pelo CreatureBuff quando dá assimilate pela primeira vez*/
	public void newPokemon(CreatureBuff buff){
		arrayBuff[0] = buff;
		print ("hue");

	}

	/*
	public CreatureBuff getBuff(int index){
		if (arrayBuff [index] != null) {
			return arrayBuff [index];
		}
	}
	*/
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			selector (0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			selector (1;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			selector (2);
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			selector (3);
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			selector (4);
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			print ("R");
		}
	}
}
