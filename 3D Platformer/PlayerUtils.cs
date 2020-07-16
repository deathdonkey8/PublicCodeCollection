using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtils : MonoBehaviour {

    //this script is used to record all stats and utilities related to the player

    public GameObject Player;
    public int Lives = 3;
    public int Score = 0;

    public static PlayerUtils instance;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
