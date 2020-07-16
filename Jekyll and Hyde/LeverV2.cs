using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverV2 : MonoBehaviour
{
    private bool tog = false;
    public GameObject Handle;
    public GameObject Target;
    public GameObject guiInput;
    private ElecOut Out;
    private Camera cam;
    private Quaternion startPos;

    void Start()
    {
        Out = gameObject.GetComponent<ElecOut>();
        startPos = Handle.transform.rotation;
        cam = Camera.main;
    }

    void Update()
    {
        //This rotates the angle of the handle to make it seem like it has bee moved
        if(tog == false)
        {
            Handle.transform.rotation = Quaternion.RotateTowards(Handle.transform.rotation, startPos, 6f);
        }
        if(tog == true)
        {
            Handle.transform.rotation = Quaternion.RotateTowards(Handle.transform.rotation, Target.transform.rotation, 6f);
        }
        guiInput.transform.LookAt(cam.transform.position);
    }


    //Collision dectection for the player stepping onto the button
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            guiInput.SetActive(true);
        }
        if(Input.GetButtonDown("Action"))
        {
            Debug.Log("press");
            if(tog == false)
            {
                tog = true;
                Out.input = true;
            }
            else
            {
                tog = false;
                Out.input = false;
            }
        }
    }
    //Turns the output to false when stepping off the button
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            guiInput.SetActive(false);
        }
    }
}