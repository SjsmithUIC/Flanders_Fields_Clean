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

	// Use this for initialization
	TerrainScript referenceScript;

	public Transform t;
	public GameObject seedPrefab;

	void Start () {
    
		powerBar = GameObject.Find("Power Bar").GetComponent<Slider>();
    	powerBar.minValue = 0f;
    	powerBar.maxValue = 10f;
    	powerBar.value = powerBarValue; 
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
      		powerBarValue += powerBarThreshold * Time.deltaTime;
			powerBar.value += powerBarThreshold * Time.deltaTime;
      
		}

		if(Input.GetKeyUp (KeyCode.Space)|| Input.GetMouseButtonUp(0))
		{
			powerBar.value = powerBarValue;
			downTimeRight = Time.time - downTimeRight;
			powerBar.value = downTimeRight;
			powerBarValue = downTimeRight;
			SpawnASeed (downTimeRight);
      		powerBarValue = 0f;
		}
	}

	void SpawnASeed(float fast){
	
		Vector3 CustomPosition = this.transform.parent.position;
		CustomPosition.y = 40;
		int i = 0;

		float rotationVariable = 0;
	
		Quaternion CustomRotation = this.transform.parent.rotation;

		while (i < 4) {
			rotationVariable = 15 * i;
			var seed = (GameObject)Instantiate (
				          seedPrefab,
				CustomPosition,
				CustomRotation);

			CustomPosition.x = CustomPosition.x + 4;
			//CustomRotation = Quaternion.Euler (0, rotationValue + rotationVariable, 0);
			CustomRotation.y += rotationVariable;


			print ("\n\n" + seed.gameObject.name + "\n\n");

		// Add velocity to the bullet
			seed.GetComponent<Rigidbody>().velocity =  (seed.transform.forward * windForce * fast);

		// Destroy the bullet after 2 seconds
		
			Destroy(seed, 10.0f);
			i++;
		}
	
	}
}
