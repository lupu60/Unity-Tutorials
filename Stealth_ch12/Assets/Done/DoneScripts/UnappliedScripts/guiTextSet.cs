using UnityEngine;
using System.Collections;

public class guiTextSet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		guiText.text = "\nArrow Keys: Move\nLeft Shift: Sneak\nZ: Use Switch\nX: Attract Attention\nF1: MainCamera\nF2: FpsCamera";
	
	}
	void Update(){
		guiText.text = "\nTime: " +Time.time+ guiText.text;
		if(Time.time>=180){
			Debug.LogWarning ("GameOver");
		}
	}

}
