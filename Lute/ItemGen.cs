using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGen : MonoBehaviour
{
    public GameObject[] Objs;
    private int selectObjs;
    private GameObject instObj;

    void Start()
    {
        StartCoroutine(generate());
    }
    IEnumerator generate()
    {
        yield return new WaitForSeconds(1/2);
        selectObjs = Random.Range(0 , Objs.Length + 4);
        if(selectObjs < Objs.Length + 4)
        {
            instObj = Instantiate(Objs[selectObjs]);
            instObj.transform.position = gameObject.transform.position;
        }
        this.enabled = false;
    }
}
