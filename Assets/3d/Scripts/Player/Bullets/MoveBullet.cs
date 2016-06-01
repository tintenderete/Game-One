using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {
	
	public float speed = 7f;
	public bool movement = true;

	
	// Update is called once per frame
	void FixedUpdate () {
		if(movement)
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		
	}
}