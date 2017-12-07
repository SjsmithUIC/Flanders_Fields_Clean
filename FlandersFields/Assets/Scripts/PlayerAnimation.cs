using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour 
{
	private Animator an;
	private Rigidbody Ridg;
	private Transform Trans;
	private float speed;
	private float direction;

	// Use this for initialization
	void Start () 
	{
		an = GetComponent<Animator>();
		Ridg = GetComponent<Rigidbody>();
		Trans = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () 
	{
		var vel = Ridg.velocity;
		direction = vel.y;
		speed = vel.magnitude;

		an.SetFloat ("Direction", direction);
		an.SetFloat ("Speed", speed);
	}
}