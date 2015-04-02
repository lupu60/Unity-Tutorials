using UnityEngine;
using System.Collections;

public class FindTheBall : MonoBehaviour {
	public Transform target;
	public  float speed;
	public static float publicspeed;
	Transform ball;
	NavMeshAgent nav;
	void Awake()
	{
		ball = GameObject.FindGameObjectWithTag("Find").transform;

		nav = GetComponent <NavMeshAgent>();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			speed = publicspeed;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
			nav.SetDestination (ball.position);

	}
}
