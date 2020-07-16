using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDectV4 : MonoBehaviour {

    private ElecOut Out;
    private Animator anim;
    List<Collider> DetCol = new List<Collider>();

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Out = gameObject.GetComponent<ElecOut>();
    }

    void Update()
    {
        if (DetCol.Count == 0)
        {
            anim.SetBool("OutputV", false);
            Out.input = false;
        }
        else
        {
            Out.input = true;
        }
    }

    //Collision dectection for the player stepping onto the button
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Movable")
        {
            anim.SetBool("OutputV", true);
            DetCol.Add(col.collider);
        }
    }
    //Turns the output to false when stepping off the button
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Movable")
        {
            DetCol.Remove(col.collider);
        }
    }
}