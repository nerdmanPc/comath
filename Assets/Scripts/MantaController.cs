using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantaController : MonoBehaviour {

	[SerializeField] private float hp;
	[SerializeField] private float speed;
	[SerializeField] private bool isSelected = false;
	[SerializeField] public GameObject prefab; //INICIALIZAR NO PREFAB
	[SerializeField] private TestPlayer myPlayer; //INICIALIZAR NO PREFAB
	private bool isWild = true; 
	private Rigidbody2D rb2D;

	public void kill(){
		Destroy (this.gameObject);
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

	public void assignPlayer(TestPlayer player){
		myPlayer = player;
	}

	void Start(){
		rb2D = GetComponent<Rigidbody2D> ();
	}

	void Update(){
		if (isSelected){
			Moviment ();
		}
	}

	void OnTriggerStay2D(Collider2D trigger){		
		if (isSelected && trigger.attachedRigidbody.gameObject.CompareTag ("lever") && Input.GetKeyDown(KeyCode.Q)) {
			GameObject go = trigger.attachedRigidbody.gameObject;
			go.GetComponent<LeverController>().action();
		}
	}

	void Moviment (){
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		rb2D.velocity =  new Vector2(horizontalMovement, verticalMovement);

		//FLIPAR SPRITE AQUI TODO
	}
}
