﻿using UnityEngine;
using System.Collections;

public class CCTVPlayerDetection : MonoBehaviour
{
	private GameObject player;                          // Reference to the player.
	private LastPlayerSighting lastPlayerSighting;      // Reference to the global last sighting of the player.
	
	
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag(Tags.player);
		lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
	}
	
	
	void OnTriggerStay (Collider other)
	{
		// If the colliding gameobject is the player...
		if(other.gameObject == player)
		{
			// ... raycast from the camera towards the player.
			Vector3 relPlayerPos = player.transform.position - transform.position;
			RaycastHit hit;
			
			if(Physics.Raycast(transform.position, relPlayerPos, out hit))
				// If the raycast hits the player...
				if(hit.collider.gameObject == player)
					// ... set the last global sighting of the player to the player's position.
					lastPlayerSighting.position = player.transform.position;
		}
	}
}