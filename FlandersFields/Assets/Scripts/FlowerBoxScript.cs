using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBoxScript : MonoBehaviour {

	public GameObject FlowerPrefab;
	public TerrainScript referenceScript;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "seed(Clone)") {					//if the seed hits the terrain

			Vector3 pos = col.transform.position;
			pos.y += 3;								

			var flower = (GameObject)Instantiate (
				             FlowerPrefab,
				             pos,
				             col.transform.rotation);

			Destroy (col.gameObject, 0f);
			Destroy (flower, 20f);

			TerrainScript.TotalFlowers++;

			if (TerrainScript.TotalFlowers == 5) {
			
				Application.LoadLevel("Result");
			
			}
		}
	}
}
