using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientNoiseAndMusicControler : MonoBehaviour 
{
	public AudioClip AmbientNoise;
	private AudioSource AN;

	public AudioClip music;
	private AudioSource Mus;

	void Awake()
	{
		AN = GetComponent<AudioSource> ();
		Mus = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () 
	{

		if (AmbientNoise != null) 
		{
			AN.PlayOneShot (AmbientNoise, 1f);
		}	

		if (music != null) 
		{
			Mus.PlayOneShot (music, 1f);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
