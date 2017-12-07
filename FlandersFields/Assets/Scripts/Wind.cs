using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wind : MonoBehaviour {

	public float windForce = 200f;
	float downTimeRight;
  	private Slider powerBar;
  	private float powerBarThreshold = 100f;
  	private float powerBarValue = 0f;
	private Text MovesLeftText;

	// Use this for initialization
	TerrainScript referenceScript;

	public Transform t;
	public GameObject seedPrefab;

	void Start () {
		MovesLeftText = GameObject.Find("MovesLeft").GetComponent<Text>();

		//powerBar = GameObject.Find("Power Bar").GetComponent<Slider>();
    	//powerBar.minValue = 0f;
    	//powerBar.maxValue = 10f;
    	//powerBar.value = powerBarValue; 
		t = GetComponent<Transform> ();
	//	cameraScript = GameObject.Find ("Camera2").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKeyDown (KeyCode.UpArrow)) {
//
//			Vector3 temp = MainCamera.transform.position;
//			temp.z = 10 + temp.z;
//
//			MainCamera.transform.SetPositionAndRotation (temp, MainCamera.transform.rotation);
//		}


		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			downTimeRight = Time.time;
      		//powerBarValue += powerBarThreshold * Time.deltaTime;
			//powerBar.value += powerBarThreshold * Time.deltaTime;
      
		}

		if(Input.GetKeyUp (KeyCode.Space)|| Input.GetMouseButtonUp(0))
		{
			//powerBar.value = powerBarValue;
			downTimeRight = Time.time - downTimeRight;
			//powerBar.value = downTimeRight;
			//powerBarValue = downTimeRight;
			SpawnASeed (downTimeRight);
      		//powerBarValue = 0f;
		}
	}

	void SpawnASeed(float fast){


		if (EventSystemScript.MovesLeft > 0) {

			EventSystemScript.MovesLeft--;
			MovesLeftText.text = "Moves: " + EventSystemScript.MovesLeft;

			Vector3 CustomPosition = t.position;
			CustomPosition.y = 40;
			int i = 0;
			int v = 1;

			float rotationVariable = 0;	
			Quaternion CustomRotation = this.transform.parent.rotation;

			float rotationValue = CustomRotation.y - 32;
			CustomRotation = Quaternion.Euler (CustomRotation.x, (rotationValue + rotationVariable), CustomRotation.z);


			while (i < 8) {
				rotationVariable = 8 * i;
				var seed = (GameObject)Instantiate (
					          seedPrefab,
					          CustomPosition,
					          t.rotation);

				CustomRotation = Quaternion.Euler (CustomRotation.x, (rotationValue + rotationVariable), CustomRotation.z);

//			seed.transform.Rotate(Vector3.up * rotationVariable, Space.World);
				//CustomRotation.y += rotationVariable;

				// Add velocity to the bullet
				if (CustomPosition.z > 400) {
					CustomPosition.x = CustomPosition.x - 5;

				}

				if (CustomPosition.z < 100) {
					CustomPosition.x = CustomPosition.x + 5;
				}

				if (CustomPosition.x < 100) {
					CustomPosition.z = CustomPosition.z - 5;

				}

				if (CustomPosition.x > 400) {
					CustomPosition.z = CustomPosition.z + 5;

				}
				seed.GetComponent<Rigidbody> ().velocity = (seed.transform.forward * windForce * fast * v);

				// Destroy the bullet after 2 seconds
		
				Destroy (seed, 10.0f);
				i++;
			}
	
		}
	}
}
