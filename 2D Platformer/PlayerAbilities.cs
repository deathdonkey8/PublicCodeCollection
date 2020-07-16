using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{

	public int AbilityState = 1;
	private PlayerMotor PB;
    private float StartSpeed;
    public float SpeedIncrease;
    public float DJump = 0;
    public Text StateText;



	// Use this for initialization
	void Start()
	{
        PB = gameObject.GetComponent<PlayerMotor>();
        StartSpeed = PB.Speed;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if (Input.GetButtonDown("Cycle") == true)
		{
            Time.timeScale = 1f;
            PB.Speed = StartSpeed;
			AbilityState = AbilityState + 1;
			if (AbilityState == 4)
			{
				AbilityState = 1;
			}
		}

		if (AbilityState == 1)
		{
            StateText.text = "Fire";
			FireBall();
		}
		else if (AbilityState == 2)
		{
            StateText.text = "Tenacity";
			Tenacity();
		}
		else if (AbilityState == 3)
		{
            StateText.text = "Slow";
			SlowTime();
		}
	}

	void FireBall()
	{
	}

	void Tenacity()
	{
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            PB.Speed = SpeedIncrease;
        }
        else
        {
           PB.Speed = StartSpeed;
        }
        if (Input.GetButtonDown("Jump") == true)
        {
            DJump = DJump + 1;
        }
        if (PB.Grounded == true)
        {
            DJump = 0;
        }

	}

	void SlowTime()
	{
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            PB.Speed = StartSpeed + (SpeedIncrease / 3);
        }
        else
        {
            Time.timeScale = 1f;
            PB.Speed = StartSpeed;
        }
	}
}
