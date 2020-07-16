using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDetection : MonoBehaviour
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
        if (Output == true)
        {
            for (int i = 0; i < Electrics.Length; i++)
            {
                Ele = Electrics[i].GetComponent<Electronics>();
                Ele.input = true;
            }
        }
        if (Output == false)
        {
            for (int i = 0; i < Electrics.Length; i++)
            {
                Ele = Electrics[i].GetComponent<Electronics>();
                Ele.input = false;
            } 
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Output = true;
            anim.SetBool("OutputV", true);
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Output = false;
            anim.SetBool("OutputV", false);
        }
    }
}
