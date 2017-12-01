using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientNoiseAndMusicControler : MonoBehaviour 
{
	public AudioClip AmbientNoise1;
	public AudioClip AmbientNoise2;
	private AudioSource AN1;
	private AudioSource AN2;

	public AudioClip music;
	private AudioSource Mus;


	void Awake()
	{
		AN1 = GetComponent<AudioSource> ();
		AN2 = GetComponent<AudioSource> ();
		Mus = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () 
	{

		if (AmbientNoise1 != null) 
		{
			AN1.PlayOneShot (AmbientNoise1, 1f);
		}

		if (AmbientNoise2 != null) 
		{
			AN2.PlayOneShot (AmbientNoise2, 1f);
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
