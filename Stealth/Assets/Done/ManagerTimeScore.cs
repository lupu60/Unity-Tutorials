using UnityEngine;
using System.Collections;

public class ManagerTimeScore : MonoBehaviour {
	public static int score;
	public static int time=180;
	public static int grenade=3;
	public GameObject guitext;
	public GameObject EndScore;
	private int sec;
	private int min;
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
		sec = time % 60;
		min = time / 60;
		//GuiTextUpdate
		guitext.guiText.text ="\nFPS: " + string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps) + "\nTime: " +string.Format("{0:00}:{1:00}", min, sec) + "\nScore: "+score + "\nHandGrenade: "+grenade;
		EndScore.guiText.text = "SCORE: " + score;
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
