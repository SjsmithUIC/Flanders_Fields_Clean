using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Flower
	{
		private GameObject flower;
		private Vector3 position;
		private float SpawnTime;
		private float DestroyTime;
		private int flowersAround;

		public Flower (GameObject f, Vector3 pos, float Spawned, float desT, int FA)
		{
			this.flower = f;
			this.position = pos;
			this.SpawnTime = Spawned;
			this.DestroyTime = desT;
			flowersAround = FA;
		}

		public void IncreaseFlower()
		{
			flowersAround++;
			ChangeDestroyTime ();
		}

		public GameObject getFlower()
		{
			return flower;
		}

		public void ChangeDestroyTime()
		{
			this.DestroyTime *= (1 + (flowersAround/10));
		}

		public float getSpawnTime()
		{
			return SpawnTime;
		}

		public Vector3 getPosition()
		{
			return position;
		}

		public float getDestroyTime()
		{
			return DestroyTime;
		}

	}
}

