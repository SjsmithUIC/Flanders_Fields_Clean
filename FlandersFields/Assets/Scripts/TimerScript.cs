﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

	private Text t;
	private float EndTime;
	private float startingtime;
	private float TimeRemaining;
	private int Minutes;
	private int Seconds;
	private Text MovesLeftText;

	// Use this for initialization
	void Start () {
		t = GameObject.Find("Timer").GetComponent<Text>();
		MovesLeftText = GameObject.Find("MovesLeft").GetComponent<Text>();
		startingtime = Time.realtimeSinceStartup;
		TimeRemaining = EventSystemScript.TotalTime;
		EndTime = startingtime + EventSystemScript.TotalTime;
		Minutes = 3;
		Seconds = 0;
		t.fontSize = 32;
	}
	
	// Update is called once per frame
	void Update () {
		TimeRemaining = EndTime - Time.realtimeSinceStartup;
		Minutes = (int)TimeRemaining / 60;
		Seconds = (int)TimeRemaining % 60;

		if (TimeRemaining % 10 >= 0.5 && TimeRemaining % 10 <= 0.5) {
			EventSystemScript.MovesLeft++;
			MovesLeftText.text = "Moves: " + EventSystemScript.MovesLeft;
		}

		if (Minutes < 10 && Seconds > 9)
			t.text = "Time: " + "0" + Minutes + ":" + Seconds;
		else if (Minutes < 10 && Seconds < 10)
			t.text = "Time: " + "0" + Minutes + ":0" + Seconds;
		else if (Minutes == 0 && Seconds < 10) {
			t.color = Color.red;
			t.text = "Time: " + "0" + Minutes + ":0" + Seconds;
		}
		
	}
}
