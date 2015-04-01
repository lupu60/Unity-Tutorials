using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndScore : MonoBehaviour {
	

	// Update is called once per frame
	void Update () {
		guiText.text = "SCORE: " + guiTextDinamic.score;
	}

}
