using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	private Transform player;
	
	NavMeshAgent nav;
	
	
	void Start ()
	{
		
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent>();
	}
	
	
	void Update ()
	{
		
		
		nav.SetDestination (player.position);
		
	}
}
