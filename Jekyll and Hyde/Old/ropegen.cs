using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropegen : MonoBehaviour 
{
    public GameObject RopeParent;
    public GameObject RopeSegment;
    private Vector3 Ropepos;
    public int SegmentCount;
    private GameObject PrevSeg;
    private GameObject CurrentSeg;

	void Start ()
    {
        PrevSeg = RopeSegment;
        Ropepos = PrevSeg.transform.position;
        for (int i = 0; i < SegmentCount; i++)
        {
            CurrentSeg = Instantiate(RopeSegment, new Vector3(Ropepos.x, Ropepos.y, Ropepos.z + 0.1f), PrevSeg.transform.rotation, RopeParent.transform);
            CurrentSeg.gameObject.GetComponent<ConfigurableJoint>().connectedBody = PrevSeg.gameObject.GetComponent<Rigidbody>();
            PrevSeg = RopeParent.transform.GetChild(i + 1).gameObject;
            Ropepos = PrevSeg.transform.position;
        }
		
	}

}
