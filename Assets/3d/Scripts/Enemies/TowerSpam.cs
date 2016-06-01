using UnityEngine;
using System.Collections;

public class TowerSpam : MonoBehaviour {

	public GameObject Ball;
	public float ballCD = 3f;
	public GameObject shooterUp;
	public GameObject shooterDown;
	public GameObject shooterLeft;
	public GameObject shooterRight;
	public bool ballUp = true;
	public bool ballDown = true;
	public bool ballLeft = true;
	public bool ballRight = true;

	private float count = 0f;

	// Use this for initialization
	void Start () {
		;
	}
	
	// Update is called once per frame
	void Update () {
		count --;
		if (count <= 0) {
			if(ballUp){
				Instantiate(Ball, shooterUp.transform.position, shooterUp.transform.rotation);
			}
			if(ballDown){
				Instantiate(Ball, shooterUp.transform.position, shooterDown.transform.rotation);
			}
			if(ballLeft){
				Instantiate(Ball, shooterUp.transform.position, shooterLeft.transform.rotation);
			}
			if(ballRight){
				Instantiate(Ball, shooterUp.transform.position, shooterRight.transform.rotation);
			}

			count = ballCD;
		}
		 

	}
}
