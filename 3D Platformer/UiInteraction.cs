using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiInteraction : MonoBehaviour {

    public GameObject play;
    private PlayerUtils Utils;
    public GameObject Hearts;
    public GameObject Score;

	// Use this for initialization
	void Start () {
        //gets the utils script in order to reference it
        Utils = play.GetComponent<PlayerUtils>();
    }
	// Update is called once per frame
	void Update () {
        //chances GUI text to the value from the utils script
        Hearts.GetComponent<Text>().text = "Lives: " + Utils.Lives.ToString();
        Score.GetComponent<Text>().text = "Score: " + Utils.Score.ToString();
	}
}
