using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronicsV2 : MonoBehaviour 
{
    public bool Output;
    public GameObject[] Inputs;
    private int OnAmmount;
    private ElecOut inp;
    public enum CircuitType
    {
        and,
        or,
        nor,
        nand,
        xor,
        xnor
    }
    public CircuitType Type;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for(int i = 0; i < Inputs.Length; i++)
        {
            Gizmos.DrawLine(gameObject.transform.position, Inputs[i].transform.position);
        }
    }

	// Use this for initialization
	void Start () 
    {
        //Setting starting varible as to not break the code
        Output = false;
        OnAmmount = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Type == CircuitType.or)
        {
            //loops through any connected components in the circuit
            for (int i = 0; i < Inputs.Length; i++)
            {
                //gets the detection script from the component , will need a v4 for other components
                inp = Inputs[i].GetComponent<ElecOut>();
                //if the component has an output of true the onamount is set to 1
                if (inp.input == true)
                {
                    OnAmmount = 1;
                }
            }
            //if the on amount is 1 then the output will be set to true and the on ammount will be reset
            if (OnAmmount == 1)
            {
                Output = true;
                OnAmmount = 0;
            }
            else
            {
                Output = false;
            }
        }
        else if (Type == CircuitType.and)
        {
            //loops through any connected components in the circuit
            for (int i = 0; i < Inputs.Length; i++)
            {
                //gets the detection script from the component , will need a v4 for other components
                inp = Inputs[i].GetComponent<ElecOut>();
                //if the component has an output of true the onamount is set to 1
                if (inp.input == true)
                {
                    OnAmmount = OnAmmount + 1;

                }
            }
            //if the on amount is 1 then the output will be set to true and the on ammount will be reset
            if (OnAmmount == Inputs.Length)
            {
                Output = true;
                OnAmmount = 0;
            }
            else
            {
                Output = false;
                OnAmmount = 0;
            }
        }
        else if (Type == CircuitType.nor)
        {
            //loops through any connected components in the circuit
            for (int i = 0; i < Inputs.Length; i++)
            {
                //gets the detection script from the component , will need a v4 for other components
                inp = Inputs[i].GetComponent<ElecOut>();
                //if the component has an output of true the onamount is set to 1
                if (inp.input == true)
                {
                    OnAmmount = 1;
                }
            }
            //if the on amount is 1 then the output will be set to true and the on ammount will be reset
            if (OnAmmount == 1)
            {
                Output = false;
                OnAmmount = 0;
            }
            else
            {
                Output = true;
            }
        }
        else if (Type == CircuitType.nand)
        {
            //loops through any connected components in the circuit
            for (int i = 0; i < Inputs.Length; i++)
            {
                //gets the detection script from the component , will need a v4 for other components
                inp = Inputs[i].GetComponent<ElecOut>();
                //if the component has an output of true the onamount is set to 1
                if (inp.input == true)
                {
                    OnAmmount = OnAmmount + 1;

                }
            }
            //if the on amount is 1 then the output will be set to true and the on ammount will be reset
            if (OnAmmount == Inputs.Length)
            {
                Output = false;
                OnAmmount = 0;
            }
            else
            {
                Output = true;
                OnAmmount = 0;
            }
        }
        else if (Type == CircuitType.xor)
        {
            //loops through any connected components in the circuit
            for (int i = 0; i < Inputs.Length; i++)
            {
                //gets the detection script from the component , will need a v4 for other components
                inp = Inputs[i].GetComponent<ElecOut>();
                //if the component has an output of true the onamount is set to 1
                if (inp.input == true)
                {
                    OnAmmount = OnAmmount + 1;

                }
            }
            //if the on amount is 1 then the output will be set to true and the on ammount will be reset
            if (OnAmmount == 1)
            {
                Output = true;
                OnAmmount = 0;
            }
            else
            {
                Output = false;
                OnAmmount = 0;
            }
        }
        else if (Type == CircuitType.xnor)
        {
            //loops through any connected components in the circuit
            for (int i = 0; i < Inputs.Length; i++)
            {
                //gets the detection script from the component , will need a v4 for other components
                inp = Inputs[i].GetComponent<ElecOut>();
                //if the component has an output of true the onamount is set to 1
                if (inp.input == true)
                {
                    OnAmmount = OnAmmount + 1;

                }
            }
            //if the on amount is 1 then the output will be set to true and the on ammount will be reset
            if (OnAmmount == 0 || OnAmmount == Inputs.Length)
            {
                Output = true;
                OnAmmount = 0;
            }
            else
            {
                Output = false;
                OnAmmount = 0;
            }
        }
	}
}
