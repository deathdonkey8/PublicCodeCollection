using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldierAi : MonoBehaviour {

    private NavMeshAgent agent;
    private GameObject Player;

	// Use this for initialization
	void Start () 
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        Player = PlayerUtils.instance.Player;
	}
	
	// Update is called once per frame
	void Update () 
    {
        agent.SetDestination(Player.transform.position);
        //gameObject.transform.LookAt(Player.transform);
	}
}
