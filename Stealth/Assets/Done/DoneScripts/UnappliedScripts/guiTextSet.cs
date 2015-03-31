using UnityEngine;
using System.Collections;

public class guiTextSet : MonoBehaviour { 
	private int secs;
	private int mins;
	private int time=180;
	// Use this for initialization
	void Start () {
		guiText.text = "\nArrow Keys: Move\nLeft Shift: Sneak\nZ: Use Switch\nX: Attract Attention\nF1: MainCamera\nF2: FpsCamera";
		StartCoroutine(UpdateTime());

	}

	void Update(){
		secs = time % 60;
		mins = time / 60;
		guiText.text = "\nTime: " +string.Format("{0:00}:{1:00}", mins, secs)+ "\nArrow Keys: Move\nLeft Shift: Sneak\nZ: Use Switch\nX: Attract Attention\nF1: MainCamera\nF2: FpsCamera" ;

		if(Time.time>=180){
			Debug.LogWarning ("GameOver");
		}

	}
	IEnumerator UpdateTime()
	{
		while(true)
		{ 	
			time -= 1;
			yield return new WaitForSeconds(1);
		}
	}
}
