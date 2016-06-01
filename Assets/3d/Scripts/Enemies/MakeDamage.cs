using UnityEngine;
using System.Collections;

public class MakeDamage : MonoBehaviour {

	private float damage;


	// Use this for initialization
	void Start () {
		damage = transform.GetComponent<GeneralLivingBeings> ().damage;
	}
	
	// Update is called once per frame


	void OnCollisionStay (Collision collision){
		if (collision.gameObject.CompareTag ("Player")) {

			collision.transform.GetComponent<GeneralLivingBeings>().TakeDamage(damage);		
		}
	}

}
