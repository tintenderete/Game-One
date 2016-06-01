using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float timeLife = 1f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, timeLife);
	}
	

}
