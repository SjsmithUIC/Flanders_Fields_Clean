using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldieerRespawn : MonoBehaviour 
{
	public pref
	public GameObject[] soldiers;
	public Transform[] Spawpoints;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < soldiers.Length; i++) 
		{
			if (soldiers [i] != null) 
			{
				if (soldiers [i].transform.position.x < 400) 
				{
					Destroy (soldiers [i]);
				}
			}
		}

		if (soldiers.Length == 0) 
		{
			int SpawnLocation = Random.Range (0, Spawpoints.Length);


		}
	}
}
