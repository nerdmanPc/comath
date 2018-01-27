using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantaBuff : MonoBehaviour, CreatureBuff {

	bool isAttached;
	int hpAmount = 20;

	public void attach(PlayerControllerScript player){
		/*TODO
		 * Ligar passivas,
		 * Destruir dono,
		 * player.addBuff(this);
		*/
		player.setDJump();
		isAttached = true;
		print (isAttached);
		player.addTotalHp (hpAmount);
	}

	public void select(){
		if (isAttached) {
			gameObject.GetComponent<PlayerControllerScript>().select();
		}else{
			gameObject.GetComponent<MantaController>().select();
		}
	}

	public void detach(PlayerControllerScript player){
		/*TODO
		 * Desligar passivas,
		 * Criar manta com X HP, e essebuff
		 * player.removeBuff(this)
		*/
		player.setDJump ();
		isAttached = false;
		player.addTotalHp (-hpAmount);
	}

	public void action(PlayerControllerScript player){
		/*TODO
		 * Notificar player
		 * executar
		*/
	}

	// Use this for initialization
	void Start () {
		isAttached = false;	
	}

	/*
	 * A criatura sabe quand ela é assimilada pela primeira vez
	 * Acriatura é responsável pela própria auto-destruição
	 * Portanto, elá é responsácel por se registrar e desregistrar do seletor
	*/

	// Update is called once per frame
	void Update () {
		
	}
		
}
