using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAi : MonoBehaviour 
{
    public int speed;
    public Transform PlayerChar;
    public Transform FaceDetection;
    private RaycastHit2D platformH;
    private RaycastHit2D wallH;
    private bool Right = true;
    private float Mag;

	// Use this for initialization
	void Start () 
    {
        Mag = Mathf.Sqrt(Mathf.Pow(PlayerChar.position.x - transform.position.x, 2) + Mathf.Pow(PlayerChar.position.y - transform.position.y, 2));
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        Mag = Mathf.Sqrt(Mathf.Pow(PlayerChar.position.x - transform.position.x, 2) + Mathf.Pow(PlayerChar.position.y - transform.position.y, 2));
        Debug.Log(Mag);
        if (Mag < 6)
        {
            //Attack();
        }
        
        platformH = Physics2D.Raycast(FaceDetection.position, -Vector2.up, 1f);
        wallH = Physics2D.Raycast(FaceDetection.position, Vector2.left, 0.02f);

        if (platformH.collider == null && Right == true)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            Right = false;
        }
        else if (platformH.collider == null && Right == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            Right = true;
        }
        StartCoroutine(faceCheck());
        transform.Translate(Vector2.right * speed * Time.deltaTime);

	}

    IEnumerator faceCheck()
    {
        if (wallH.collider && Right == true && wallH.collider.gameObject.tag != "Player")
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            yield return new WaitForEndOfFrame();
            Right = false;
        }
        else if (wallH.collider && Right == false && wallH.collider.gameObject.tag != "Player")
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            yield return new WaitForEndOfFrame();
            Right = true;
        }
    }

    void Attack()
    {
        speed = 0;
    }
}
