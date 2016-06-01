using UnityEngine;
using System.Collections;

public class Meteoro : MonoBehaviour {

	public float damage = 50f;



	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.CompareTag ("PlayerBody")) {
			collider.gameObject.GetComponentInParent<GeneralLivingBeings>().TakeDamage(damage);
		}
	}
}
