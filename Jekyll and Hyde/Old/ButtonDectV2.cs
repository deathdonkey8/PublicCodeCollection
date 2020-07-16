using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDectV2 : MonoBehaviour
{
    public bool Output = false;
    public GameObject[] Electrics;
    private Electronics Ele;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   //Collision dectection for the player stepping onto the button
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetBool("OutputV", true);
            for (int i = 0; i < Electrics.Length; i++)
            {
                Ele = Electrics[i].GetComponent<Electronics>();
                Ele.input = true;
            }
        }
    }

    //makes sure that is any glitchy business happens that the output will still stay as true
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetBool("OutputV", true);
            for (int i = 0; i < Electrics.Length; i++)
            {
                Ele = Electrics[i].GetComponent<Electronics>();
                Ele.input = true;
            }
        }
    }

    //Turns the output to false when stepping off the button
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetBool("OutputV", false);
            for (int i = 0; i < Electrics.Length; i++)
            {
                Ele = Electrics[i].GetComponent<Electronics>();
                Ele.input = false;
            } 
        }
    }
}

