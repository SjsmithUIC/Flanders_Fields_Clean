using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour 
{
	//Create two variables to hold the target and the navmesh for the object
	public Transform[] target;
	NavMeshAgent CurrentNavMesh;


	// Use this for initialization
	void Start () 
	{
		CurrentNavMesh = this.GetComponent<NavMeshAgent> ();

		if (CurrentNavMesh == null) 
		{
			
		} 

		else 
		{
			SetDest ();
		}
	}

	private void SetDest()
	{
		if(target.Length != 0)
		{
			int TargNum = randomNum (target.Length - 1);
			Vector3 TVect = target[TargNum].transform.position;
			CurrentNavMesh.SetDestination(TVect);
		}
	}

	private int randomNum(int Length)
	{
		return Random.Range (0, Length);
	}

	public void AddNavPoints(Transform[] T)
	{
		target = T;
	}

	//edited by anas

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "CanonBullet(Clone)") {
			Destroy (this, 0f);
		}
	}


}
