using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour 
{
    public bool PowerOn;
    private Electronics inputV;
    private Light Lights;

	// Use this for initialization
	void Start () 
    {
        inputV = gameObject.GetComponent<Electronics>();
        Lights = gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (inputV.input == true)
        {
            PowerOn = true;
        }
        else
        {
            PowerOn = false;
        }
	}

    void LateUpdate()
    {
        if (PowerOn == true)
        {
            Lights.enabled = true;
        }
        if (PowerOn == false)
        {
            Lights.enabled = false;
        }
    }
}
