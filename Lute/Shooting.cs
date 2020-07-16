using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	
	public ParticleSystem Shoot;

	// Use this for initialization
	void Start () {
		Shoot.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot.Play();
		}
		if (Input.GetButtonUp("Fire1"))
		{
			Shoot.Stop();
		}
	}
}
