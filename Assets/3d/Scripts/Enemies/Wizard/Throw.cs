using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour {

	public GameObject Shooter;
	public float shootCD = 5f;
	public GameObject BasicBall;
	public float damageBasicBall = 30;
	public GameObject Meteoro;
	public float damageMeteoro = 30;
	public float countAtrack = 3f;
		
	private GameObject Player;
	private bool playerInRange = false;
	private bool shootAvailable = true;
	private Rigidbody rb;
	private GameObject topSpam;
	private float rangeTopSpam = 15;
	private float count = 0f;

	// Use this for initialization

	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		topSpam = GameObject.FindGameObjectWithTag ("TopSpam");
		rb = GetComponent<Rigidbody> (); 
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (playerInRange) {
			Rotation();
		}

		if (playerInRange) {

			if(count > countAtrack ){
				MeteoroAttack();
				count = 0;

			}
			if(shootAvailable){
				count++;
				StartCoroutine (BasicAttack ());

			}

		}

	}

	void OnTriggerStay(Collider collider){

		if (collider.gameObject.CompareTag ("PlayerBody")) {
			playerInRange = true;
		}
	}
	void OnTriggerExit(Collider collider){
		
		if (collider.gameObject.CompareTag ("PlayerBody")) {
			playerInRange = false;
		}
	}

	IEnumerator BasicAttack(){

		Instantiate (BasicBall, Shooter.transform.position, Shooter.transform.rotation);
		shootAvailable = false;
		yield return new WaitForSeconds(shootCD);
		shootAvailable = true;

	}

	void Rotation(){
		Vector3 rotation = Player.transform.position - transform.position;
		rotation = rotation.normalized;
		Quaternion newRotation = Quaternion.LookRotation (rotation);
		rb.rotation = newRotation;
	}

	void MeteoroAttack(){
		float newX = topSpam.transform.position.x + Random.Range (-rangeTopSpam, rangeTopSpam);
		Vector3 newPos = new Vector3 (newX, topSpam.transform.position.y, topSpam.transform.position.z);
		Vector3 newDirection = (Player.transform.position - newPos).normalized;
		Quaternion newRotation = Quaternion.LookRotation (newDirection);
		Instantiate (Meteoro, newPos, newRotation);


	}




}
