using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public Transform Pivot;
    public Transform player;
	public Vector3 offset;
	public bool useOffsetValues;
	public float rotateSpeed;

	// Use this for initialization
	void Start ()
	{
		Cursor.lockState = CursorLockMode.Locked;

		if (!useOffsetValues)
		{
			offset = target.position - transform.position;
		}

		Pivot.position = target.position;
		Pivot.parent = target.transform;

	}
		
	// Update is called once per frame
	void LateUpdate ()
	{
        float horizontal = (Input.GetAxisRaw("Mouse X") + Input.GetAxisRaw("Stick X")) * rotateSpeed;
        float vertical = (Input.GetAxisRaw("Mouse Y") + Input.GetAxisRaw("Stick Y")) * rotateSpeed;
		Pivot.Rotate(-vertical, 0, 0);
        target.Rotate(0, horizontal, 0);
        target.position = player.position;
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            player.rotation = target.rotation;
        }

		//Limit Camera rotation up down
		if (Pivot.rotation.eulerAngles.x > 45f && Pivot.rotation.eulerAngles.x < 180f)
		{
			Pivot.rotation = Quaternion.Euler (45f, 0, 0);
		}

		if (Pivot.rotation.eulerAngles.x > 180f && Pivot.rotation.eulerAngles.x < 315f)
		{
			Pivot.rotation = Quaternion.Euler (315f, 0, 0);
		}

		//Move camera based on rotation of target
		float newYAngle = target.eulerAngles.y;
		float newXAngle = Pivot.eulerAngles.x;

		Quaternion rotatian = Quaternion.Euler(newXAngle, newYAngle, 0);
		transform.position = target.position - (rotatian * offset);

		if (transform.position.y < target.position.y -1f) 
		{
			transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
		}

		transform.LookAt (target);

	}
}
