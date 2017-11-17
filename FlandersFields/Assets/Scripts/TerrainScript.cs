using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour {


	Wind referenceScript;
	public GameObject FlowerPrefab;
	public GameObject ExplosionPrefab;

	static public int TotalFlowers = 0;
	public int score = 0;

	void Start(){

		referenceScript = GameObject.Find ("Wind").GetComponent<Wind>();
	}
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "seed(Clone)") {					//if the seed hits the terrain

			//Vector3 pos = col.transform.position;
			//pos.y += 3;								

			//var flower = (GameObject)Instantiate (
			//	FlowerPrefab,
			//	pos,
			//	col.transform.rotation);

			Destroy (col.gameObject, 0f);
			//Destroy (flower, 20f);

		}

		if(col.gameObject.name == "CanonBullet(Clone)") {			//if the canon bullet hits the terrain

			var explosion = (GameObject)Instantiate (
				ExplosionPrefab,
				col.transform.position,
				col.transform.rotation);

			Destroy (col.gameObject, 0f);
			Destroy (explosion, 2f);

		}
	}
}
	

