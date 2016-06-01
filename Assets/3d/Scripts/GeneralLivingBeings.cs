using UnityEngine;
using System.Collections;

public class GeneralLivingBeings : MonoBehaviour {

	public float health;
	public float damage;
	
	public Interface _interface;

	private GameLogic gameLogic;
	private SaveBinary save;
	void Start(){
		GameObject aux = GameObject.FindGameObjectWithTag("Player");
		_interface = aux.GetComponent<Interface> ();
		aux = GameObject.FindGameObjectWithTag("Game logic");
		gameLogic = aux.GetComponent<GameLogic> ();
		save = GetComponent<SaveBinary> ();
	}


	public void TakeDamage(float damage){
		health -= damage;

	}
	public void Dead(){
			Destroy (gameObject);
	}

	void Update(){
		if (health <= 0f) {
			if(gameObject.CompareTag("Player")){
				save.Save();
				Application.LoadLevel("Death");
			}else{
				_interface.currentScore++;
				gameLogic.EnemiesCount--;
				Destroy(gameObject);
			}


		}
	} 

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Bullet")) {
			TakeDamage(collision.gameObject.GetComponent<Damage>().damage);
			
		}
	}









}
