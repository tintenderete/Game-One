using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	
	public float speed = 10f;
	public Rigidbody rb;
	private Vector3 movement;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	
	void FixedUpdate () {
		
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");
		Move (v, h);

		
	}
	
	
	void Move (float v, float h) {
		
		float _speed;
		
		
		if (v != 0f && h != 0f) {
			_speed = speed * 0.7f;
		} else {
			_speed = speed;
		}
		

		// Set the movement vector based on the axis input.
		movement.Set (h, 0f, v);
		
		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * _speed * Time.deltaTime;
		
		// Move the player to it's current position plus the movement.
		rb.MovePosition (transform.position + movement);
		
		
	}
}