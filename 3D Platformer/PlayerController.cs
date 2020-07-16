using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public CharacterController cc;
	public float jumpStrength;
	public float gravityScale;
    public bool allowedDouble;
    public GameObject Graphics;


	private Vector3 moveDirection;
    private Vector3 GraphicDir;

	//--Use this for initialization--
	void Start ()
	{
		
		//Automaticaly sets cc to a cController on the component
		cc = GetComponent<CharacterController>();
        allowedDouble = true;

	}
	
	//--Happens every frame at the start--
	void Update ()
	{

        //--Input Calculations and adjusting the Graphics to the correct rotation--

		//moveDirection = new Vector3 (Input.GetAxis ("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis ("Vertical") * moveSpeed);
		float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        GraphicDir = moveDirection;
        moveDirection.y = yStore;
        Debug.DrawRay(transform.position, -transform.up * 5, Color.green);

        //--

		//--Checks to see if the player is on the ground and while the double jump varible is true allows a double jump while in the air--
		if (cc.isGrounded)
		{
			moveDirection.y = 0f;
            allowedDouble = true;

			//Makes the character jump
			if (Input.GetButtonDown("Jump"))
			{
				moveDirection.y = jumpStrength;
			}
		}

		if (!cc.isGrounded)
		{
			
            if (allowedDouble == true && Input.GetButtonDown("Jump"))
            {
                Debug.Log("up");
                //resets the vertical momentum in order to allow for a double jump
                moveDirection.y = 0f;
                moveDirection.y = jumpStrength;
                allowedDouble = false;
            }

		}
        //--
		
	}

    //--Happens at the end of every frame--
    void LateUpdate()
    {
        if (Input.GetAxisRaw("Vertical") != 0|| Input.GetAxisRaw("Horizontal") != 0)
        {
            Graphics.transform.rotation = Quaternion.LookRotation(GraphicDir);
        }
        //having the vertical momentum callculated at the end of the frame allows for the double jump to cancel out the momentum
        moveDirection.y = moveDirection.y + (Physics.gravity.y * (gravityScale*10) * Time.deltaTime); 
        //moves the character
        cc.Move(moveDirection * Time.deltaTime);
    }
}
