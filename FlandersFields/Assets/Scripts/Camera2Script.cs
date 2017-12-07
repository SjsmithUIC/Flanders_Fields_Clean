using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2Script : MonoBehaviour {

	public GameObject wind;       //Public variable to store a reference to the player game object


	private Vector3 offset;         //Private variable to store the offset distance between the player and camera

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
//		Quaternion rotation = Quaternion.Euler(new Vector3(30, 0, 0));
//		transform.position = Vector3.Lerp(this.transform.position, new Vector3(250,100,100), 2f);
//		transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, 2f);
	}

	void moveCamera(Vector3 position, Quaternion rotation)
	{
		transform.position = Vector3.Lerp(this.transform.position, new Vector3(250,100,100), 2f);
		transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, 2f);

	}
}
