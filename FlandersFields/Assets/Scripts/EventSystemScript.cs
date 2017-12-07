using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventSystemScript : MonoBehaviour {

	public static float StartingTime;
	public static int TotalTime = 120;
	private Text ResultText;
	public static int MovesLeft = 5;

	// Use this for initialization
	void Start () {
		//ResultText = GameObject.Find("ResultText").GetComponent<Text>();
		StartingTime = Time.realtimeSinceStartup;
//		TotalTime = 300;
	}
	
	// Update is called once per frame
	void Update () {
		if (TerrainScript.getFlowerCount () >= 100) {

			//if (ResultText != null)
				//ResultText.text = "You Win";

			SceneManager.LoadScene ("Result");
		}


		if ((Time.realtimeSinceStartup - StartingTime) > TotalTime) {

			//if (ResultText != null)
				//ResultText.text = "You Lose";

			SceneManager.LoadScene ("Result");
		}
		
	}
}
