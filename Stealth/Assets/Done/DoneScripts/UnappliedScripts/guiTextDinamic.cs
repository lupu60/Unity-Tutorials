using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class guiTextDinamic : MonoBehaviour {
	public static int score;
	public static int time=180;
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
		//Show fps
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		//Show timer
		secs = time % 60;
		mins = time / 60;
		//GuiTextUpdate
		guiText.text ="\nFPS: " + string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps) + "\nTime: " +string.Format("{0:00}:{1:00}", mins, secs) + "\nScore: "+score ;

	
	}
	//Decrease time
	IEnumerator UpdateTime()
	{
		while(true)
		{ 	
			time -= 1;
			yield return new WaitForSeconds(1);
		}
	}
}
