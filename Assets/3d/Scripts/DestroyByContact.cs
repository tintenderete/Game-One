using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {


	void OnCollisionEnter(Collision collision) {
		Destroy (gameObject);
	}
}
