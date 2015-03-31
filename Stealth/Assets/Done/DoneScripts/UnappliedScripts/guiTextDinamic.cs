using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class guiTextDinamic : MonoBehaviour {
	public int time=180;
	public static int score;
	private int secs;
	private int mins;
	private float deltaTime = 0.0f;
	// Use this for initialization
	void Start () {
		StartCoroutine(UpdateTime());
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//fps
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		string text_fps = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		//timer
		secs = time % 60;
		mins = time / 60;
		//guitextupdate
		guiText.text ="\nFPS: " + text_fps + "\nTime: " +string.Format("{0:00}:{1:00}", mins, secs) + "\nScore: "+score ;

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
