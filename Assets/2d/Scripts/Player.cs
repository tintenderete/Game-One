using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 3f;
	public float forceJump;
	public bool jumpAvailable = false;
	private Vector2 movement;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	

	void FixedUpdate () {

		float h = Input.GetAxisRaw("Horizontal");

		move (h);

		if (Input.GetAxisRaw ("Vertical") > 0 && jumpAvailable) {
			jump();
		}
	}

	void move(float h){
		movement.Set (h, 0f);
		movement = movement.normalized;
		float force = h * speed;
		rb.AddForce (new Vector2(force, 0f));


	}

	void jump(){
		rb.AddForce (new Vector2 (0f, forceJump));
	}

	void OnTriggerStay2D(Collider2D other){
			jumpAvailable = true;
	}
	void OnTriggerExit2D(Collider2D other){
		if(other)
			jumpAvailable = false;
	}

}
