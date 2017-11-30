using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using UnityEngine.UI;

public class TerrainScript : MonoBehaviour {

	private List<Flower> Flowers;
	public GameObject FlowerPrefab;
	public GameObject ExplosionPrefab;
	private float DestroyTime;
	private static int flowerCount = 0;
	private Text FlowerCountText;

	static public int TotalFlowers = 0;
	public int score = 0;

	void Start(){
		Flowers = new List<Flower>();
		FlowerCountText = GameObject.Find("FlowerCount").GetComponent<Text>();
	}

	void Update()
	{
		int total = Flowers.Count;     //slows down with large amount of flowers
		float timeNow = Time.realtimeSinceStartup;
		Flower temp;
		for(int i = 0; i < Flowers.Count; i++){
			temp = Flowers[i];

			float spawnT = temp.getSpawnTime ();
			float desT = temp.getDestroyTime ();

			if (spawnT + desT <= timeNow) {			
				Destroy (Flowers[i].getFlower (), 0f);
				flowerCount--;
				FlowerCountText.text = flowerCount.ToString();
				Flowers.Remove(Flowers[i]);
				i--;
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
		
				if ((posX + 50 < F_Pos.x && posZ + 50 < F_Pos.z) || (posX + 50 < F_Pos.x && posZ - 50 < F_Pos.z) || (posX - 50 < F_Pos.x && posZ + 50 < F_Pos.z) || (posX - 50 < F_Pos.x && posZ - 50 < F_Pos.z)) {
					f.IncreaseFlower ();
					flowersAround++;
				}
			}

			Flower flo = new Flower (Aflower, pos, currentTime , 10f, flowersAround);

			flowerCount++;
			Flowers.Add (flo);
			FlowerCountText.text = flowerCount.ToString();


			Destroy (col.gameObject, 0f);
			//Destroy (Aflower, 20f);

		}

		if(col.gameObject.name == "CanonBullet(Clone)") {			//if the canon bullet hits the terrain

			var explosion = (GameObject)Instantiate (
				ExplosionPrefab,
				col.transform.position,
				col.transform.rotation);

			float posX = col.transform.position.x; float posZ = col.transform.position.z;


//			foreach (Flower f in Flowers) {
//				Vector3 F_Pos = f.getPosition();
//
//				if ((posX + 50 < F_Pos.x && posZ + 50 < F_Pos.z) || (posX + 50 < F_Pos.x && posZ - 50 < F_Pos.z) || (posX - 50 < F_Pos.x && posZ + 50 < F_Pos.z) || (posX - 50 < F_Pos.x && posZ - 50 < F_Pos.z)) {
//					Destroy (f.getFlower(), 0f);
//					flowerCount--;
//				}
//			}

			for (int i = 0; i < Flowers.Count; i++) {
				Vector3 F_Pos = Flowers[i].getPosition();

				if ((posX + 50 < F_Pos.x && posZ + 50 < F_Pos.z) || (posX + 50 < F_Pos.x && posZ - 50 < F_Pos.z) || (posX - 50 < F_Pos.x && posZ + 50 < F_Pos.z) || (posX - 50 < F_Pos.x && posZ - 50 < F_Pos.z)) {
					Destroy (Flowers[i].getFlower(), 0f);
					Flowers.Remove (Flowers [i]);
					flowerCount--;
					i--;
				}
			}

			Destroy (col.gameObject, 0f);
			Destroy (explosion, 2f);

		}
	}
}
	

