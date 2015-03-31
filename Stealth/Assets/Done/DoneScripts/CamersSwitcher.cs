using UnityEngine;
using System.Collections;

public class CamersSwitcher : MonoBehaviour {
	public Camera MainCam;
	public Camera FpsCam;
	public GameObject player;
	// Use this for initialization
	void Start () {
		MainCam.camera.enabled = true;
		FpsCam.camera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F1)) {
			MainCam.camera.enabled = true;
			FpsCam.camera.enabled = false;
		}
		if (Input.GetKeyDown (KeyCode.F2)) {
			MainCam.camera.enabled = false;
			FpsCam.camera.enabled = true;
			//Destroy(player.GetComponents(DonePlayerMovement));
			//Destroy(player.GetComponent<DonePlayerMovement>());
			//player.AddComponent("CharacterMotor");
			//player.AddComponent("FPSInputController");

		}
	}
}
