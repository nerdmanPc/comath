using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantaBuff : MonoBehaviour, CreatureBuff {

	[SerializeField] MantaController controller;
	bool isAttached = false;
	//isWild = true;
	int hpAmount = 20;

	public void attach(PlayerControllerScript player){
		if (isAttached) {
			Debug.Log ("Buff já está assimilado!\n");
			return;
		}
		if (controller.getIsWild ()) {
			player.getPokedex().newPokemon (this);
			controller.suicide ();
		} else {
			controller.suicide ();
		}
		player.setDJump();
		isAttached = true;
		player.addTotalHp (hpAmount);
	}

	public void detach(PlayerControllerScript player){
		/*TODO
		 * CRIAR MANTA
		*/
		player.setDJump ();
		isAttached = false;
		player.addTotalHp (-hpAmount);
	}
	
	public void select(){
		if (isAttached) {
			gameObject.GetComponent<PlayerControllerScript>().select();
		}else{
			gameObject.GetComponent<MantaController>().select();
		}
	}
	
	public void deselect(){
		if (isAttached) {
			gameObject.GetComponent<PlayerControllerScript>().deselect();
		}else{
			gameObject.GetComponent<MantaController>().deselect();
		}
	}

	public void action(PlayerControllerScript player){
		/*TODO
		 * Notificar player
		 * executar
		*/
		Debug.Log ("Ação do Buff indisponível\n");
	}
	
	void Start () {
		controller = GetComponent<MantaController> ();
	}

	// Use this for initialization


	/*
	 * A criatura sabe quand ela é assimilada pela primeira vez
	 * Acriatura é responsável pela própria auto-destruição
	 * Portanto, elá é responsácel por se registrar e desregistrar do seletor
	*/
}
