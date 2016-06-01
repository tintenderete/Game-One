using UnityEngine;
using System.Collections;

public class WizzardBasicBall : MonoBehaviour {

	 
	private float damage;
	// Use this for initialization
	void Start () {
		damage = GameObject.FindGameObjectWithTag ("Wizard").GetComponent<Throw>().damageBasicBall;
	}
	

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.CompareTag ("PlayerBody")) {
			collider.gameObject.GetComponentInParent<GeneralLivingBeings>().TakeDamage(damage);
		}
	}
}
