using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PartyTime : MonoBehaviour {
	private GameObject player;		 
	public GameObject eff;
	public static bool dancing;
	// Use this for initialization

	void Awake ()
	{	
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag (DoneTags.player);
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other)
	{	dancing = true;
		// If the colliding gameobject is the player...
		if(other.gameObject == player)
		{	eff.SetActive(true);
			// ... play the clip at the position of the key...
			audio.Play();
			guiTextDinamic.score+=100;
		}
	}
	void OnTriggerExit(Collider other) {
		dancing = false;
		if(other.gameObject == player)
		{	eff.SetActive(false);
			audio.Stop();
		}
	}
}
