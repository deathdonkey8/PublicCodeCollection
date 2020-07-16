using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackelHyde : MonoBehaviour
{

    public float Speed;
    private GameObject JHObject;
    private GameObject HHObject;
    public Transform Jackel;
    private Transform JackelG;
    private Transform HydeG;
    public Transform Hyde;
    public Transform Soul;
    public Transform JackRA;
    public Transform HydeRA;
    public Transform JackHoldP;
    public Transform HydeHoldP;
    private bool JackelState = true;
    private bool JackHolding = false;
    private bool HydeHolding = false;
    private Vector3 movement;
    private Vector3 Pmov;
    private RaycastHit Rayhit;

    void Start()
    {
        //the default state for the soul is for it to start with Jackel
        Soul.position = Jackel.position;
        JackelG = Jackel.GetChild(0);
        HydeG = Hyde.GetChild(0);
            
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Jump") == true && JackelState == true)
        {
            JackelState = false;
            Soul.position = Vector3.Lerp(Soul.position, Hyde.position, Time.deltaTime/60f);

        }
        else if (Input.GetButtonDown("Jump") == true && JackelState == false)
        {
            JackelState = true;
            Soul.position = Jackel.position;
        }
        if (Input.GetButtonDown("Fire1") == true)
        {
            Pickup();
        }

	}

    void FixedUpdate()
    {
        
        movement = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        if (JackelState == true)
        {
            Soul.transform.position = Jackel.transform.position;
            Pmov = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, 0, Input.GetAxis("Vertical") * Time.deltaTime);
            Pmov = Pmov * Speed;
            Jackel.transform.Translate(Pmov);
            if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
            JackelG.transform.rotation = Quaternion.LookRotation(movement);
            }
        }
        else if (JackelState == false)
        {
            Soul.transform.position = Hyde.transform.position;
            Pmov = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, 0, Input.GetAxis("Vertical") * Time.deltaTime);
            Pmov = Pmov * Speed;
            Hyde.transform.Translate(Pmov);
            if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                HydeG.transform.rotation = Quaternion.LookRotation(movement);
            }
        }
    }

    void Pickup()
    {
        if (JackelState == true)
        {
            if (JackHolding == false)
            {
                Debug.DrawRay(JackRA.position, JackRA.forward, Color.red, 20f);
                Physics.Raycast(JackRA.position, JackRA.forward, out Rayhit, 20f);
                if (Rayhit.collider.gameObject.tag == "Movable")
                {
                    Debug.Log("Hit the cube");
                    JHObject = Rayhit.collider.gameObject;
                    Rayhit.collider.gameObject.transform.parent = JackRA;
                    JHObject.GetComponent<Rigidbody>().useGravity = false;
                    JHObject.GetComponent<Rigidbody>().isKinematic = true;
                    JHObject.transform.position = JackHoldP.position;
                    JackHolding = true;
                }
            }
            else
            {
                JHObject.transform.parent = null;
                JHObject.GetComponent<Rigidbody>().isKinematic = false;
                JHObject.GetComponent<Rigidbody>().useGravity = true;
                JHObject = null;
                JackHolding = false;
            }
        }
        else
        {
            if (HydeHolding == false)
            {
                Debug.DrawRay(HydeRA.position, HydeRA.forward, Color.red, 20f);
                Physics.Raycast(HydeRA.position, HydeRA.forward, out Rayhit, 20f);
                if (Rayhit.collider.gameObject.tag == "Movable")
                {
                    Debug.Log("Hit the cube");
                    HHObject = Rayhit.collider.gameObject;
                    Rayhit.collider.gameObject.transform.parent = HydeRA;
                    HHObject.GetComponent<Rigidbody>().useGravity = false;
                    HHObject.GetComponent<Rigidbody>().isKinematic = true;
                    HHObject.transform.position = HydeHoldP.position;
                    HydeHolding = true;
                }
            }
            else
            {
                HHObject.transform.parent = null;
                HHObject.GetComponent<Rigidbody>().isKinematic = false;
                HHObject.GetComponent<Rigidbody>().useGravity = true;
                HHObject = null;
                HydeHolding = false;
            }
        }
    }
}
