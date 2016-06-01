using UnityEngine;
using System.Collections;

public class FloorHarmFull : MonoBehaviour {

	public float damage = 25f;
	public float clovesDamageCD = 2f;
	public float timeClovesUP = 3f;
	public float timeClovesDown = 3f;
	public GameObject Cloves;	

	private bool playerOnTrigger = false;
	private bool clovesUp = false;
	private bool newCloves = true;
	private float countDamageCloves = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (newCloves) {
			StartCoroutine(ClovesPosition());
		}

		if (playerOnTrigger && clovesUp) {
			countDamageCloves--;
			if(countDamageCloves <= 0){
				GameObject.FindGameObjectWithTag("PlayerBody").GetComponentInParent<GeneralLivingBeings>().TakeDamage(damage);
				countDamageCloves = clovesDamageCD;
			}
		}
			
	}

	IEnumerator ClovesPosition(){

		Cloves.transform.Translate (0f, 0.3f,0);
		//Animacion
		clovesUp = true;
		newCloves = false;
		yield return new WaitForSeconds(timeClovesUP);
		Cloves.transform.Translate (0f, -0.3f,0);
		clovesUp = false;
		yield return new WaitForSeconds(timeClovesDown);
		newCloves = true;
	}

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.CompareTag ("PlayerBody")) {
			playerOnTrigger = true;
			countDamageCloves = 0;
		}
	}
	void OnTriggerExit(Collider collider){
		
		if (collider.gameObject.CompareTag ("PlayerBody")) {
			playerOnTrigger = false;

		}
	}

}
