using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool PowerOn = false;
    private ElectronicsV2 input;
    private Vector3 startPos;
    public float speedMultiplyer = 1f;
    public GameObject targetPos;

	// Use this for initialization
	void Start () 
    {
        //initiating the Input varible and lights to be used later
        input = gameObject.GetComponent<ElectronicsV2>();
        startPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //if the output from ElectronicsV2 is true it will turn the parents power on
        //but if it isnt on it makes sure it is false every frame
        if (input.Output == true)
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
        if(PowerOn == true)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPos.transform.position, 0.002f * speedMultiplyer);
        }
        else if(PowerOn == false)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, startPos, 0.002f * speedMultiplyer);
        }
    }
}
