using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {


	public GameObject[] enemiesArray;
	public GameObject[] pointsArray;
	
	public int MaxEnemiesCount = 40;
	public int EnemiesCount = 0;
	public float reSpamCD = 10f;

	private float countReSpam = 0f;


	private AudioSource musicBackGround;

	// Use this for initialization
	void Start () {

		musicBackGround = GetComponent<AudioSource> ();
		SpawmEnemies ();
		musicBackGround.Play ();
	}
	
	// Update is called once per frame

	void Update () {

		countReSpam += Time.deltaTime;
		if (countReSpam >= reSpamCD) {
			if(EnemiesCount >= MaxEnemiesCount){

			}else{
				SpawmEnemies();
				countReSpam = 0f;
			}

		}

	}

	void SpawmEnemies(){
		foreach (GameObject point in pointsArray) {
			EnemiesCount++;
			Instantiate(enemiesArray[Random.Range(0, enemiesArray.Length)],
			            point.gameObject.transform.position,
			            point.gameObject.transform.rotation);
		}
	}


}
