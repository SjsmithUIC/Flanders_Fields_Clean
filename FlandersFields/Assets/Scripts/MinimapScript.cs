using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour {

	GameObject [] Soldiers;
	// Use this for initialization
	void Start () {
		Soldiers = new GameObject[15];
		Soldiers [0] = GameObject.Find ("Capsule").GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
