using UnityEngine;
using System.Collections;

public class FindTheBall : MonoBehaviour {
	Transform player;
	NavMeshAgent nav;
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Find").transform;

		nav = GetComponent <NavMeshAgent>();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination(player.position);
	}
}
