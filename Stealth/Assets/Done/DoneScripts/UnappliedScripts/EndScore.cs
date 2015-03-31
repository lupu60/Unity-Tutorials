using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndScore : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "\nScore: " + guiTextDinamic.score;
	}

}
