using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool PowerOn;
    private ElectronicsV2 inputV;
    private Animator anim;

    // Use this for initialization
    void Start () 
    {
        inputV = gameObject.GetComponent<ElectronicsV2>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () 
    {
        if (inputV.Output == true)
        {
            PowerOn = true;
        }

        if (inputV.Output == false)
        {
            PowerOn = false;
        }
    }

    void LateUpdate()
    {
        if (PowerOn == true)
        {
            anim.SetBool("OutputV", true);
        }
        if (PowerOn == false)
        {
            anim.SetBool("OutputV", false);
        }
    }
}
