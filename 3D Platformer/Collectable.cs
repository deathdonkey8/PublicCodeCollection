using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public enum Type{Lives, Score}
    public Type type;
    public int Value;
    private PlayerUtils Utils;
    public GameObject Player;

    void Start ()
    {
        Utils = Player.GetComponent<PlayerUtils>();
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Touched");
            if (type == Type.Lives)
            {
                Utils.Lives += Value;
            }
            else if (type == Type.Score)
            {
                Utils.Score += Value;  
            }
            Destroy(gameObject);
        }
    }

}
