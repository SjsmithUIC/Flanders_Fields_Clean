using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSystemScript : MonoBehaviour {

	public static float StartingTime;
	public static int TotalTime = 300;

	// Use this for initialization
	void Start () {
		StartingTime = Time.realtimeSinceStartup;
//		TotalTime = 300;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.realtimeSinceStartup - StartingTime) > 300) {
			SceneManager.LoadScene ("Result");

		}
		
	}
}
