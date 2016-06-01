using UnityEngine;
using System.Collections;

public class TurnPlayer : MonoBehaviour {
	

	private Rigidbody rb;
	private int floorMask;
	private Vector3 playerToMouse;


	// Use this for initialization
	void Start () {

		floorMask = LayerMask.GetMask("Floor");
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Turning ();

	}

	void Turning(){
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;
		
		// Perform the raycast and if it hits something on the floor layer...
		if(Physics.Raycast (camRay, out floorHit, 1000f, floorMask))
		{	
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			playerToMouse = floorHit.point - transform.position;
			
			// Ensure the vector is entirely along the floor plane.
			playerToMouse.y = 0f;
			
			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			
			
			rb.MoveRotation (newRotation);
			
		}
	}
	
	
	public Vector3 GetDirection(){
		return playerToMouse;
	}
}