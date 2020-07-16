using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour 
{
    private bool tog = false;
    public GameObject guiInput;
    private ElecOut Out;

    void Start()
    {
        Out = gameObject.GetComponent<ElecOut>();
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