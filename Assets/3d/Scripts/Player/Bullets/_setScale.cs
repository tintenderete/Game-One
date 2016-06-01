using UnityEngine;
using System.Collections;

public class _setScale : MonoBehaviour {

	public void _SetScale(float x, float y, float z){

		transform.localScale = new Vector3 (x, y, z);

	}
}
