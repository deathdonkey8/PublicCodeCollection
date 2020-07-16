using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDoor : MonoBehaviour
{
    public bool PowerOn = false;
    private ElectronicsV2 input;
    private ElecOut electricOut;
    private Collider gateway;

    public GameObject activeGraphics;

	// Use this for initialization
	void Start () 
    {
        //initiating the Input varible and lights to be used later
        input = gameObject.GetComponent<ElectronicsV2>();
        electricOut = gameObject.GetComponent<ElecOut>();
        gateway = gameObject.GetComponent<BoxCollider>();
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
    //Update called at the end of the frame
    void LateUpdate()
    {
        //if the power is on then anything internal will switch on
        if (PowerOn == true)
        {
            activeGraphics.SetActive(true);
            gateway.enabled = true;
        }
        if (PowerOn == false)
        {
            activeGraphics.SetActive(false);
            gateway.enabled = false;
        }
    }

    private void OnTriggerStay(Collider col)
    {
        Debug.Log("Boop");
        if(col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            electricOut.input = true;
        }
    }
}

