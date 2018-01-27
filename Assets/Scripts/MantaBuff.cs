using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantaBuff : MonoBehaviour, CreatureBuff {

	void attach(PlayerControllerScript player){
		/*TODO
		 * Ligar passivas,
		 * Destruir dono,
		 * player.addBuff(this);
		*/
	}

	void detach(PlayerControllerScript player){
		/*TODO
		 * Desligar passivas,
		 * Criar manta com X HP, e essebuff
		 * player.removeBuff(this)
		*/
	}

	void action(PlayerControllerScript player){
		/*TODO
		 * Notificar player
		 * executar
		*/
	}

	// Use this for initialization
	void Start () {
		
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
