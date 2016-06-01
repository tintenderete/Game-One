using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public bool blockedDoor = false;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("PlayerBody")) {
			if(!blockedDoor)
			OpenDoor ();
		} 
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("PlayerBody")) {
			if(!blockedDoor)
			CloseDoor();
		}
	}

	void OpenDoor(){
		anim.SetBool ("DoorIsOpen", true);
	}
	void CloseDoor(){
		anim.SetBool ("DoorIsOpen", false);

	}

	public void BlockedDoor(){
		blockedDoor = true;
		CloseDoor ();
	}


}
