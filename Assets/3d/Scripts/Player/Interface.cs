using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interface : MonoBehaviour {

	public Slider sliderHealth;
	public Image Weapon1;
	public Image Weapon2;
	public Text Score;

	public float currentScore;

	private float weapon;

	private GameObject Player;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		sliderHealth.maxValue = Player.GetComponent<GeneralLivingBeings>().health;
		
		
	}
	// Update is called once per frame
	void Update () {
		sliderHealth.value = Player.GetComponent<GeneralLivingBeings>().health;

		Score.text = "Score: " + currentScore;

		if (Player.GetComponent<ShootingPlayer> ().currentWeapon == 1f) {
			Weapon1.color = Color.blue;
			Weapon2.color = Color.white;
		} else {
			Weapon1.color = Color.white;
			Weapon2.color = Color.blue;
		}
	}
}
