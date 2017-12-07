using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapScript : MonoBehaviour {

	//AIMovement [] Soldiers;
	string [] SoldierNames;
	public CanonScript [] Canons;
	string [] CanonNames = {"Canon1", "Canon2", "Canon3"};

	// Use this for initialization
	void Start () {
		//Soldiers = new AIMovement[15];
		SoldierNames = new string [15];
		Canons = new CanonScript[3];
//		getSoldiers ();
//		getCanons ();
	}
	
	// Update is called once per frame
	void Update () {
		getSoldiers ();
		getCanons ();
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == checkSoldier(col.gameObject) || col.gameObject.name == "SoldierPrefab(Clone)") {					//if the seed hits the terrain

			CanonScript canon = closerCanon (col.gameObject);
			//Canons[0].CanonFire (col.gameObject);
			canon.CanonFire (col.gameObject.transform.position);

			Destroy (col.gameObject);
		}

		if (col.gameObject.name == "seed(Clone)") {					//if the seed hits the terrain
			Destroy (col.gameObject);
		}

		if (col.gameObject.name == "PoppyFlower(Clone)") {					//if the seed hits the terrain
			Destroy (col.gameObject);
		}

	}

	string checkSoldier(GameObject a)
	{
		int i = 0;
		while (i < 15) {

			if (a.name == SoldierNames[i])
				return a.name;

			i++;
		}

		return null;
	}

	void getSoldiers()					//right now they are capsules
	{
		SoldierNames[0] = "DefaultAvatar";

		int i = 1;
		while (i < 15) {
		
			SoldierNames[i] = "DefaultAvatar (" + i + ")";
			i++;
		}

	}

	void getCanons(){

		int i = 0;
		while (i < 3) {

			Canons[i] = GameObject.Find (CanonNames[i]).GetComponent<CanonScript>();
			i++;
		}

	
	}

	CanonScript closerCanon(GameObject a){
		
		if (Distance (a, Canons [0]) >= Distance (a, Canons [1]) && Distance (a, Canons [0]) >= Distance (a, Canons [2])) {

			return Canons [0];		
		}

		else if(Distance (a, Canons [1]) >= Distance (a, Canons [0]) && Distance (a, Canons [1]) >= Distance (a, Canons [2])) {

			return Canons [1];		
		}

		else
			return Canons [2];		
		
	}

	float Distance(GameObject a, CanonScript b)
	{
		return Mathf.Sqrt(((a.transform.position.x - b.transform.position.x)*(a.transform.position.x - b.transform.position.x))
			+ 	((a.transform.position.z - b.transform.position.z)*(a.transform.position.z - b.transform.position.z)));
	}

}
