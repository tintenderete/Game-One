using UnityEngine;
using System.Collections;

public class MeteoroShadow : MonoBehaviour {

	public GameObject meteoroShadow;

	private int floor; 
	private Ray shootRay;
	private RaycastHit shootHit;
	private GameObject Player;
	// Use this for initialization
	void Start () {

		Player = GameObject.FindGameObjectWithTag("Player");
		floor = LayerMask.GetMask("Floor");

		shootRay.direction = (Player.transform.position - transform.position).normalized;
		shootRay.origin = transform.position;
		
		if (Physics.Raycast (shootRay, out shootHit, 1000f, floor)) {
			Instantiate (meteoroShadow, shootHit.point, shootHit.transform.rotation);
		} 
	}
	

}

 