using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class TerrainScript : MonoBehaviour {

	private List<Flower> Flowers;
//	private Wind referenceScript;			//just made this private
	public GameObject FlowerPrefab;
	public GameObject ExplosionPrefab;
	private float DestroyTime;

	static public int TotalFlowers = 0;
	public int score = 0;

	void Start(){
		Flowers = new List<Flower>();
//		referenceScript = GameObject.Find ("Wind").GetComponent<Wind>();
	}

	void Update()
	{
		int total = Flowers.Count;
		foreach (Flower f in Flowers) {

//		for(int i = 0; i < total; i++)
		float timeNow = Time.realtimeSinceStartup;
		float spawnT = f.getSpawnTime ();
		float desT =f.getDestroyTime ();

			if (spawnT + desT <= timeNow) {			
				Destroy (f.getFlower (), 0f);
//				Flowers.RemoveAt ();
			}
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "seed(Clone)") {					//if the seed hits the terrain

			Vector3 pos = col.transform.position;
			int flowersAround = 0;
			pos.y += 1;								

			var Aflower = (GameObject)Instantiate (
				FlowerPrefab,
				pos,
				col.transform.rotation);

			float currentTime = Time.realtimeSinceStartup;

			float posX = pos.x; float posZ = pos.z;

			foreach (Flower f in Flowers) {
				Vector3 F_Pos = f.getPosition();
		
				if ((posX + 50 < F_Pos.x && posZ + 50 < F_Pos.z) || (posX + 50 < F_Pos.x && posZ - 50 < F_Pos.z) || (posX - 50 < F_Pos.x && posZ + 50 < F_Pos.z) || (posX - 50 < F_Pos.x && posZ - 50 < F_Pos.z))
					flowersAround++;
			}

			Flower flo = new Flower (Aflower, pos, currentTime , 20f, flowersAround);

			Flowers.Add (flo);

			Destroy (col.gameObject, 0f);
			//Destroy (Aflower, 20f);

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
	

