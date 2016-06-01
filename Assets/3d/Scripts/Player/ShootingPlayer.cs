using UnityEngine;
using System.Collections;


	
	public class ShootingPlayer : MonoBehaviour {
		
		
		public GameObject shootBall;
		public GameObject shooter;
		public GameObject _shootBall;
		public GameObject _shootBallFalse;	
		
		public float _damagePlus = 4f;
		public float shootCD = 5f;
		public float maxScale = 2f;
		public float scale = 0.1f;

		private bool shootAvailable = true;
		private bool fire1Press = false;
		public float currentWeapon = 1f;
		
		private GameObject _currentBallFalse;
		
		private AudioSource ShootClip;
		

		// Use this for initialization
		void Start () {
			ShootClip = GetComponent<AudioSource> ();
		}
		
		// Update is called once per frame
		
		void Update(){

			_update ();

		}	

		void FixedUpdate () {

			_update ();

		}

	void _update(){

		if (Input.GetButtonDown ("Fire1")) {
			fire1Press = true;
		}
		
		if (Input.GetButtonUp ("Fire1")) {
			fire1Press = false;
		}	
		
		if (Input.GetButtonDown ("1")) {
			currentWeapon = 1f;
		}
		
		if (Input.GetButtonDown ("2")) {
			currentWeapon = 2f;
		}
		
		if (currentWeapon == 1) {
			Weapon1();
		}
		
		if (currentWeapon == 2) {
			Weapon2();
		}
	}

	void Weapon1(){

		if (fire1Press && shootAvailable) {
			StartCoroutine (ShootW1 ());
		}
	}
	
	IEnumerator ShootW1(){
		ShootClip.Play ();
		Instantiate(shootBall, shooter.transform.position, shooter.transform.rotation);
		shootAvailable = false;
		yield return new WaitForSeconds(shootCD);
		shootAvailable = true;
		
	}

	void Weapon2(){

		if (fire1Press) {

			ChargeShootW2 ();

		} 
		if(!fire1Press && _currentBallFalse){

			ShootW2();

		}

	}

	void ChargeShootW2(){

		if(_currentBallFalse){
			if(_currentBallFalse.transform.localScale.y <= maxScale)
			{
				_currentBallFalse.transform.localScale = new Vector3(_currentBallFalse.transform.localScale.x + scale * Time.deltaTime,
				                                                     _currentBallFalse.transform.localScale.y + scale * Time.deltaTime,
				                                                     _currentBallFalse.transform.localScale.z + scale * Time.deltaTime
				                                                     );
			}
			
			
		}
		else
		{
			_currentBallFalse = Instantiate(_shootBallFalse, shooter.transform.position, shooter.transform.rotation) as GameObject;
			_currentBallFalse.transform.parent = shooter.transform;
		}
	}

	void ShootW2(){
		ShootClip.Play ();
		GameObject aux = Instantiate(_shootBall, shooter.transform.position, shooter.transform.rotation ) as GameObject;

		_setScale set = aux.GetComponent<_setScale> ();

		set._SetScale (_currentBallFalse.transform.localScale.x * 0.3f,
                     	_currentBallFalse.transform.localScale.y * 0.3f,
                     	_currentBallFalse.transform.localScale.z * 0.3f
		);

		Damage damage = aux.GetComponent<Damage> ();

		damage.SetDamage ((damage.damage * aux.transform.localScale.y) * _damagePlus);
		
		Destroy(_currentBallFalse);
	}




}

