using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	public float damage = 10f;

	public void  SetDamage(float newDamage){
		damage = newDamage;
	}
}
