using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro1 : MonoBehaviour {

  public int level = 1;
  public int timevar = 4;

	// Use this for initialization
	void Start () {
    //StartCoroutine(TIME());
    //Application.LoadLevel(level);


  }

  IEnumerator TIME()
  {
    print(Time.time);
    Debug.Log(Time.time);
    yield return new WaitForSeconds(timevar);
    print(Time.time);
    Debug.Log(Time.time);
  }
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown("space"))
      Application.LoadLevel(level);
	}
}
