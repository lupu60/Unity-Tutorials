using UnityEngine;
using System.Collections;

public class DonePlayerMovement : MonoBehaviour
{
	public AudioClip shoutingClip;		// Audio clip of the player shouting.
	public float turnSmoothing = 15f;	// A smoothing value for turning the player.
	public float speedDampTime = 0.1f;	// The damping for the speed parameter

	private Animator anim;				// Reference to the animator component.
	private DoneHashIDs hash;			// Reference to the HashIDs.
	public GameObject grenade;
	private GameObject grenadeClone;
	private Vector3 throwSpeed = new Vector3(2, 16, 30); //This value is a sure basket

	
	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(DoneTags.gameController).GetComponent<DoneHashIDs>();
		
		// Set the weight of the shouting layer to 1.
		anim.SetLayerWeight(1, 1f);
		anim.SetLayerWeight(2, 2f);
		anim.SetLayerWeight(3, 3f);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
		}
	}
	void FixedUpdate ()
	{
		// Cache the inputs.
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		bool sneak = Input.GetButton("Sneak");
		
		MovementManagement(h, v, sneak);
	}

	
	void Update ()
	{	
		if (PartyTime.dancing == true) {
			anim.SetBool ("Dancing", true);
		} else {
			anim.SetBool("Dancing",false);
		}
		if (Input.GetMouseButtonDown(1)) {
			if(ManagerTimeScore.grenade>0){
			anim.SetBool ("Throwing", true);
			grenadeClone = Instantiate(grenade, transform.position, transform.rotation) as GameObject;
			grenadeClone.rigidbody.AddForce(throwSpeed, ForceMode.Impulse);
			FindTheBall.publicspeed = 6;
			ManagerTimeScore.grenade-=1;
			}

		}
		if (Input.GetMouseButtonUp(1)) {
			anim.SetBool ("Throwing", false);
			
		}
		// Cache the attention attracting input.
		bool shout = Input.GetButtonDown("Attract");
		
		// Set the animator shouting parameter.
		anim.SetBool(hash.shoutingBool, shout);
		
		AudioManagement(shout);
	}
	void MovementManagement (float horizontal, float vertical, bool sneaking)
	{
		// Set the sneaking parameter to the sneak input.
		anim.SetBool(hash.sneakingBool, sneaking);
		
		// If there is some axis input...
		if(horizontal != 0f || vertical != 0f)
		{
			// ... set the players rotation and set the speed parameter to 5.5f.
			Rotating(horizontal, vertical);
			anim.SetFloat(hash.speedFloat, 5.5f, speedDampTime, Time.deltaTime);
		}
		else
			// Otherwise set the speed parameter to 0.
			anim.SetFloat(hash.speedFloat, 0);
	}

	
	void Rotating (float horizontal, float vertical)
	{ 

		// Create a new vector of the horizontal and vertical inputs.
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
		
		// Create a rotation based on this new vector assuming that up is the global y axis.
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		
		// Create a rotation that is an increment closer to the target rotation from the player's rotation.
		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		
		// Change the players rotation to this new rotation.
		rigidbody.MoveRotation(newRotation);
		
		// Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		// RaycastHit floorHit;
		
		// if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
		// {
		// 	Vector3 playerToMouse = floorHit.point - transform.position;
		// 	playerToMouse.y = 0f;
			
		// 	Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
		// 	playerRigidbody.MoveRotation(newRotation);
		// }
}

	void AudioManagement (bool shout)
	{
		// If the player is currently in the run state...
		if(anim.GetCurrentAnimatorStateInfo(0).nameHash == hash.locomotionState)
		{
			// ... and if the footsteps are not playing...
			if(!audio.isPlaying)
				// ... play them.
				audio.Play();
		}
		else
			// Otherwise stop the footsteps.
			audio.Stop();
		
		// If the shout input has been pressed...
		if(shout)
			// ... play the shouting clip where we are.
			AudioSource.PlayClipAtPoint(shoutingClip, transform.position);
	}
}
