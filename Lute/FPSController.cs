using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public Transform Piv;
    public float JumpS;
    [Range(1f , 10f)]
    public float Sensitiviy = 1f;
    public float Speed = 2f;
    public GameObject GroundedAncor;


    private float RotZ = 0f;
    private Vector3 JumpVec = new Vector3(0,0,0);
    private RaycastHit Rayhit;
    private bool grounded;
    private Rigidbody PlayerRDG;

	// Use this for initialization
	void Start ()
    {
        PlayerRDG = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Handles the rotation of the Camera
        if (Input.GetAxis("Mouse X") != 0)
        {
            gameObject.transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * Sensitiviy, 0);
        }
        // Y Rotation
        RotZ += -Input.GetAxis("Mouse Y") * Sensitiviy;
        RotZ = Mathf.Clamp(RotZ, -90, 90);
        Piv.eulerAngles = new Vector3(Piv.eulerAngles.x, Piv.eulerAngles.y, RotZ);
        gameObject.transform.Translate(-(Input.GetAxis("Vertical") / Speed), -JumpVec.y, Input.GetAxis("Horizontal") / Speed);
        Physics.Raycast(GroundedAncor.transform.position, -GroundedAncor.transform.up, out Rayhit, 0.1f);
        if(Rayhit.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        if(grounded == true)
        {
            JumpVec.y = 0f;
        }

    }
    void Update()
    {
        PlayerRDG.AddForce(JumpVec * Time.deltaTime);
        StartCoroutine(detection());
    }

    private IEnumerator detection()
    {
        if(Input.GetButtonDown("Jump") && grounded == true)
        {
            JumpVec.y = -JumpS / 100;
        }
        return null;
    }

}
