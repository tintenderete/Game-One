using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	private GameObject Player;
	private Vector3 distance;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");

		distance = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Player.transform.position + distance;
	}
}
