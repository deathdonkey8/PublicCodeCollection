using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

	public Transform Player;
	public float Speed;
	public bool JumpPhase = false;
    public bool Grounded = false;
    public int JumpStrength;
	public float Mass;
	private Rigidbody2D rb;
    public Transform GroundDetection;
    public float TerminalVelocity;
    private RaycastHit2D hit;
    private PlayerAbilities PA;

	// Use this for initialization
	void Start()
	{
        PA = gameObject.GetComponent<PlayerAbilities>();
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
    void OnCollisionExit2D()
    {
        Grounded = false;
    }

	void FixedUpdate()
    {
        hit = Physics2D.Raycast(GroundDetection.position, -Vector2.up, 0.002f);
        if (hit.collider == null)
        {
            Grounded = false;
        }
		Player.position = new Vector2(Player.position.x + (Input.GetAxisRaw("Horizontal") * Speed) * Time.deltaTime, Player.position.y);
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        StartCoroutine(Jump());
	}

	void OnCollisionStay2D(Collision2D other)
	{
        if (other.gameObject.tag == "Ground" && hit.collider)
		{
            JumpPhase = true;
            Grounded = true;
            rb.velocity = new Vector2(0, 0);
		}
	}

	IEnumerator Jump()
	{
        if (JumpPhase == true && Input.GetAxisRaw("Jump") == 1)
		{
            if (PA.AbilityState != 2 || PA.DJump > 3)
            {
                JumpPhase = false;
            }
            for(int i = JumpStrength; i > 1; i--)
            {
                rb.velocity = new Vector2(0, i);
                yield return new WaitForSeconds(1/2 + 1/4);
            }
		}
        if (JumpPhase == true && Grounded == false)
        {
            while (Grounded == false && rb.velocity.y > -TerminalVelocity)
            {
                rb.velocity = new Vector2(0, rb.velocity.y - 1);
                yield return new WaitForSeconds(2);
            }
        }
		if (JumpPhase == false)
		{
            if (Grounded == false)
            {
                while (Grounded == false && rb.velocity.y > -TerminalVelocity)
                {
                    rb.velocity = new Vector2(0, rb.velocity.y - 1);
                   yield return new WaitForSeconds(2);
                }
            }
		}
        if (Grounded == true)
        {
            rb.velocity = new Vector2(0, 0);
        }
            
	}

}
