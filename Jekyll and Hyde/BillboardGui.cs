using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardGui : MonoBehaviour {

    public Camera Cam;

	void Update () 
    {
        transform.LookAt(transform.position + Cam.transform.rotation * Vector3.forward, Cam.transform.rotation * Vector3.up);
	}
}
