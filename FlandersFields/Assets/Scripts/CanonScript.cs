using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonScript : MonoBehaviour {

	public Transform t;
	public GameObject BulletPrefab;

	public float BulletForward = 2f;
	public float BulletUpward = 2f;
	public float BulletRotationValue = 10;
	public Vector3 temp;

	// Use this for initialization
	void Start () {
		t = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyUp (KeyCode.F))
		{

			CanonFire (temp);
		}

	}


	public void CanonFire(Vector3 a){

		Vector3 CustomPosition = t.position;
		CustomPosition.y += 100;
		Quaternion CustomRotation;

		int randomInt = 0;

		if (t.position.z == 500) {

			randomInt = Random.Range (-180, -90);
		} else if (t.position.z == 250) {
			randomInt = Random.Range (-135, -45);
		} else if (t.position.z == 0) {
			randomInt = Random.Range (-90, 0);
		}

		CustomRotation = Quaternion.Euler (t.rotation.x,t.rotation.y + randomInt,t.rotation.z);

		var Bullet = (GameObject)Instantiate (
				BulletPrefab,
				CustomPosition,
				CustomRotation);

		print ("\n\n" + Bullet.gameObject.name + "\n\n");

		if (a != null) {
			//Bullet.transform.position = Vector3.Lerp(CustomPosition, a, 0.25f);
			//		Bullet.transform.position = a;
			Bullet.transform.position = a;
//			Bullet.GetComponent<Rigidbody> ().velocity = (Bullet.transform.up * BulletUpward);
//			Bullet.GetComponent<Rigidbody> ().velocity = (Bullet.transform.forward * BulletForward);
		}
		else {
			Bullet.GetComponent<Rigidbody>().velocity =  (Bullet.transform.up * BulletUpward);
			Bullet.GetComponent<Rigidbody>().velocity =  (Bullet.transform.forward * BulletForward);
		}
			// Add velocity to the bullet
		//Bullet.GetComponent<Rigidbody>().velocity =  (Bullet.transform.up * BulletUpward);
		//Bullet.GetComponent<Rigidbody>().velocity =  (Bullet.transform.forward * BulletForward);
			// Destroy the bullet after 2 seconds
//		Bullet.transform.Find ("Capsule");
		Destroy(Bullet, 20.0f);
	}

	public IEnumerator MoveOverSeconds (GameObject objectToMove, Vector3 end, float seconds)
	{
		float elapsedTime = 0;
		Vector3 startingPos = objectToMove.transform.position;
		while (elapsedTime < seconds)
		{
			objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		objectToMove.transform.position = end;
	}
}
