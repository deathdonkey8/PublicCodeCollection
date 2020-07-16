using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour 
{
    private Vector3 Direction;
    public float speed;

    void OnCollisionStay(Collision col)
    {
        Direction = transform.forward;
        Direction = Direction * speed;
        col.rigidbody.AddForce(Direction, ForceMode.Force);
	}
}
