using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldieerRespawn : MonoBehaviour 
{
	public int AutoKillIterations = 2;
	private int iterations = 0;
	public float TimeBetweenWaves = 30f;
	public int SoldiersOnField = 23;
	public GameObject SoldierPrefab;
	public GameObject[] soldiers;
	public Transform[] Spawpoints;
	public Transform[] NavPoints;

	public AudioClip TrenchWhistle;
	private AudioSource TW;
	public AudioClip fighting;
	private AudioSource F;

	void Awake()
	{
		TW = GetComponent<AudioSource> ();	
		F = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () 
	{
		SoldierPrefab.GetComponent<AIMovement> ().AddNavPoints (NavPoints);
		InvokeRepeating ("OverTheTop", TimeBetweenWaves, TimeBetweenWaves);
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < soldiers.Length; i++) 
		{
			if (soldiers [i] != null) 
			{
				if (soldiers [i].transform.position.x < 185) 
				{
					Destroy (soldiers [i]);
				}
			}
		}
	}

	void OverTheTop()
	{
		if (iterations < AutoKillIterations) 
		{
			if (allDead ()) 
			{
				TW.PlayOneShot (TrenchWhistle, .6f);
				F.PlayOneShot (fighting, .6f);

				for (int i = 0; i < SoldiersOnField; i++) 
				{
					int SpawnLocation = Random.Range (0, Spawpoints.Length);

					soldiers [i] = Instantiate (SoldierPrefab, Spawpoints [SpawnLocation].position, Spawpoints [SpawnLocation].rotation);
				}

				iterations = 0;
			} 

			else 
			{
				iterations = iterations + 1;
			}
		} 

		else 
		{
			
			for(int i = 0; i < soldiers.Length; i++)
			{
				if(soldiers[i] != null)
				{
					Destroy (soldiers [i]);
				}
			}

			TW.PlayOneShot (TrenchWhistle, .6f);
			F.PlayOneShot (fighting, .6f);

			for (int i = 0; i < SoldiersOnField; i++) 
			{
				int SpawnLocation = Random.Range (0, Spawpoints.Length);

				soldiers [i] = Instantiate (SoldierPrefab, Spawpoints [SpawnLocation].position, Spawpoints [SpawnLocation].rotation);
			}

			iterations = 0;
		}
	}

	bool allDead()
	{
		bool alldead = true;
		for (int i = 0; i < soldiers.Length; i++) 
		{
			if (soldiers [i] != null) 
			{
				alldead = false;
			}
		}

		return alldead;
	}
}
