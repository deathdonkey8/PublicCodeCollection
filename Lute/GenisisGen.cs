using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenisisGen : MonoBehaviour {

	private RaycastHit Rayhit;
    public GameObject NorthAncor;
    public GameObject SouthAncor;
    public GameObject EastAncor;
    public GameObject WestAncor;
    public GameObject northWall;
    public GameObject southWall;
    public GameObject eastWall;
    public GameObject westWall;
    private GameObject NewCell;
    public GameObject[] UniRooms;
    public GameObject[] NorthRooms;
    public GameObject[] SouthRooms;
    public GameObject[] EastRooms;
    public GameObject[] WestRooms;
    public GameObject Limit;
    private int RoomType;
    private int RoomIndex;
    private int RoomLimit;

    private Vector3 NorthRay;
    private Vector3 SouthRay;
    private Vector3 EastRay;
    private Vector3 WestRay;



    // Use this for initialization
    void Start()
    {

        NorthRay = new Vector3(NorthAncor.transform.position.x, NorthAncor.transform.position.y + 1, NorthAncor.transform.position.z);
        SouthRay = new Vector3(SouthAncor.transform.position.x, SouthAncor.transform.position.y + 1, SouthAncor.transform.position.z);
        EastRay = new Vector3(EastAncor.transform.position.x, EastAncor.transform.position.y + 1, EastAncor.transform.position.z);
        WestRay = new Vector3(WestAncor.transform.position.x, WestAncor.transform.position.y + 1, WestAncor.transform.position.z);

        Limit = GameObject.Find("Count");
		RoomLimit = Limit.GetComponent<RoomCountScript>().RoomLimit;
        if (NorthAncor != null)
        {
            //North();
            Gen(northWall, NorthAncor, NorthRay, NorthRooms, UniRooms);
        }
        if (SouthAncor != null)
        {
            //South();
            Gen(southWall, SouthAncor, SouthRay, SouthRooms, UniRooms);
        }

        if (EastAncor != null)
        {
            //East();
            Gen(eastWall, EastAncor, EastRay, EastRooms, UniRooms);
        }

        if (WestAncor != null)
        {
            //West();
           Gen(westWall, WestAncor, WestRay, WestRooms, UniRooms);
        }
    }

    void Gen(GameObject Wall, GameObject Anc, Vector3 cRay, GameObject[] DirRoom, GameObject[] UniRoom)
    {
        Physics.Raycast(cRay, -Anc.transform.up, out Rayhit, 20f);
        if (Rayhit.collider == true)
        {
            if(Rayhit.collider.tag == "Room")
            {
                Wall.SetActive(false);
                Destroy(Anc);
            }
            if (Rayhit.collider.tag == "DCell")
            {
                Wall.SetActive(true);
                Destroy(Anc);
            }
        }
        if (Rayhit.collider != true && Limit.transform.position.y < RoomLimit)
        {
            RoomType = Random.Range(0, 3);
            if (RoomType == 0 || RoomType == 2)
            {
                //A random room in the array is selected to be spawned and then is spawned
                RoomIndex = Random.Range(0, UniRooms.Length);
                NewCell = Instantiate(UniRooms[0], Anc.transform.position, Anc.transform.rotation);
                NewCell.name = "Cell" + Limit.transform.position.y.ToString();
                Wall.SetActive(false);
            }
            if (RoomType == 1)
            {
                //A random room in the array is selected to be spawned and then is spawned
                RoomIndex = Random.Range(0, NorthRooms.Length);
                NewCell = Instantiate(DirRoom[RoomIndex], Anc.transform.position, DirRoom[RoomIndex].transform.rotation);
                NewCell.name = "Cell" + Limit.transform.position.y.ToString();
                Wall.SetActive(true);
            }
            Limit.transform.position = new Vector3(Limit.transform.position.x, Limit.transform.position.y + 1, Limit.transform.position.z);
            Destroy(Anc);
        }
        else if(Limit.transform.position.y == RoomLimit && Rayhit.collider != true)
        {
            Wall.SetActive(true);
            Destroy(Anc);
        }
    }

}