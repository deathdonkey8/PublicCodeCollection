using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDectV3 : MonoBehaviour
{
    public bool Output = false;
    private Electronics Ele;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    //Collision dectection for the player stepping onto the button
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Movable")
        {
            anim.SetBool("OutputV", true);
            Output = true;
        }
    }

    //makes sure that is any glitchy business happens that the output will still stay as true
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Movable")
        {
            anim.SetBool("OutputV", true);
            Output = true;
        }
    }

    //Turns the output to false when stepping off the button
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Movable")
        {
            anim.SetBool("OutputV", false);
            Output = false;
        }
    }
}
