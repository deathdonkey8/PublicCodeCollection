using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

    //allows for axis of rotation choice
    public enum RotAxis{x,y,z};
    public RotAxis RotationAxis;
    [Range(-100f, 100f)]
    public float Speed;
	
	// Update is called once per frame
	void Update ()
	{
        //carries out the rotation
        if (RotationAxis == RotAxis.z)
        {

            transform.Rotate(0f, 0f, Speed);
        }
        if (RotationAxis == RotAxis.y)
        {

            transform.Rotate(0f, Speed, 0f);
        }
        if (RotationAxis == RotAxis.x)
        {

            transform.Rotate(Speed, 0f, 0f);
        }

	}
}
