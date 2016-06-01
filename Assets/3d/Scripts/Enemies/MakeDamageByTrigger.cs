using UnityEngine;
using System.Collections;

public class MakeDamageByTrigger : MonoBehaviour {


	public float damage = 20;

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.CompareTag ("PlayerBody")) {
			collider.gameObject.GetComponentInParent<GeneralLivingBeings>().TakeDamage(damage);
		}
	}
}
