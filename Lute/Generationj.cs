using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generationj : MonoBehaviour
{

    private RaycastHit Rayhit;
    public GameObject CurRoom;
    public GameObject NorthAncor;
    public GameObject SouthAncor;
    public GameObject EastAncor;
    public GameObject WestAncor;
    public GameObject[] UniRooms;
    public GameObject[] NorthRooms;
    public GameObject[] SouthRooms;
    public GameObject[] EastRooms;
    public GameObject[] WestRooms;
    public GameObject Limit;
    private int RoomType;
    private int RoomIndex;
    private int RoomLimit = 90;


    // Use this for initialization
    void Start()
    {
        Limit = GameObject.Find("Count");
        if (NorthAncor != null)
        {
            North();
        }
        if (SouthAncor != null)
        {
            South();
        }
        if (EastAncor != null)
        {
            East();
        }
        if (WestAncor != null)
        {
            West();
        }
    }

    //NorthAncor Room Spawning
    void North()
    {
        //Raycast to detect if there is already a room in the space
        Physics.Raycast(NorthAncor.transform.position, -NorthAncor.transform.up, out Rayhit, 20f);
        if (Rayhit.collider == false && Limit.transform.position.y < RoomLimit || Rayhit.collider.tag != "Room" && Limit.transform.position.y < RoomLimit)
        {
            //When the space is clear a random number is chosen from 0 and 1 coinsiding with a room type either Universal or Directional
            RoomType = Random.Range(0, 2);
            //Using a woldspace block on a y axis as a room limit
            Limit.transform.position = new Vector3(Limit.transform.position.x, Limit.transform.position.y + 1f, Limit.transform.position.x);

            if (RoomType == 0)
            {
                //A random room in the array is selected to be spawned and then is spawned
                RoomIndex = Random.Range(0, UniRooms.Length);
                Instantiate(UniRooms[RoomIndex], NorthAncor.transform.position, UniRooms[RoomIndex].transform.rotation);
            }
            if (RoomType == 1)
            {
                //A random room in the array is selected to be spawned and then is spawned
                RoomIndex = Random.Range(0, NorthRooms.Length);
                Instantiate(NorthRooms[RoomIndex], NorthAncor.transform.position, NorthRooms[RoomIndex].transform.rotation);
            }
            //the spawn anchor is deleted as it is no longer needed
            Destroy(NorthAncor);
        }
    }

    //SouthAncor Room Spawning
    void South()
    {
        Physics.Raycast(SouthAncor.transform.position, -SouthAncor.transform.up, out Rayhit, 20f);
        if (Rayhit.collider == false && Limit.transform.position.y < RoomLimit || Rayhit.collider.tag != "Room" && Limit.transform.position.y < RoomLimit)
        {
            //When the space is clear a random number is chosen from 0 and 1 coinsiding with a room type either Universal or Directional
            RoomType = Random.Range(0, 2);
            //Using a woldspace block on a y axis as a room limit
            Limit.transform.position = new Vector3(Limit.transform.position.x, Limit.transform.position.y + 1f, Limit.transform.position.x);

            if (RoomType == 0)
            {
                //A random room in the array is selected to be spawned and then is spawned
                RoomIndex = Random.Range(0, UniRooms.Length);
                Instantiate(UniRooms[RoomIndex], SouthAncor.transform.position, UniRooms[RoomIndex].transform.rotation);
            }
            if (RoomType == 1)
            {
                //A random room in the array is selected to be spawned and then is spawned
                RoomIndex = Random.Range(0, SouthRooms.Length);
                Instantiate(SouthRooms[RoomIndex], SouthAncor.transform.position, SouthRooms[RoomIndex].transform.rotation);
            }
            //the spawn anchor is deleted as it is no longer needed
            Destroy(SouthAncor);
        }
    }

    //EastAncor Room Spawning
    void East()
    {
        Physics.Raycast(EastAncor.transform.position, -EastAncor.transform.up, out Rayhit, 20f);
        if (Rayhit.collider == false && Limit.transform.position.y < RoomLimit || Rayhit.collider.tag != "Room" && Limit.transform.position.y < RoomLimit)
        {
            //When the space is clear a random number is chosen from 0 and 1 coinsiding with a room type either Universal or Directional
            RoomType = Random.Range(0, 2);
            //Using a woldspace block on a y axis as a room limit
            Limit.transform.position = new Vector3(Limit.transform.position.x, Limit.transform.position.y + 1f, Limit.transform.position.x);

            if (RoomType == 0)
            {
                //A random room in the array is selected to be spawned and then is spawned
                RoomIndex = Random.Range(0, UniRooms.Length);
                Instantiate(UniRooms[RoomIndex], EastAncor.transform.position, UniRooms[RoomIndex].transform.rotation);
            }
            if (RoomType == 1)
            {
                //A random room in the array is selected to be spawned and then is spawned
                RoomIndex = Random.Range(0, EastRooms.Length);
                Instantiate(EastRooms[RoomIndex], EastAncor.transform.position, EastRooms[RoomIndex].transform.rotation);
            }
            //the spawn anchor is deleted as it is no longer needed
            Destroy(EastAncor);
        }
    }

    //WestAncor Room Spawning
    void West()
    {
        Physics.Raycast(WestAncor.transform.position, -WestAncor.transform.up, out Rayhit, 20f);
        if (Rayhit.collider == false && Limit.transform.position.y < RoomLimit || Rayhit.collider.tag != "Room" && Limit.transform.position.y < RoomLimit)
        {
            //When the space is clear a random number is chosen from 0 and 1 coinsiding with a room type either Universal or Directional
            RoomType = Random.Range(0, 2);
            //Using a woldspace block on a y axis as a room limit
            Limit.transform.position = new Vector3(Limit.transform.position.x, Limit.transform.position.y + 1f, Limit.transform.position.x);

            if (RoomType == 0)
            {
                //A random room in the array is selected to be spawned and then is spawned
                RoomIndex = Random.Range(0, UniRooms.Length);
                Instantiate(UniRooms[RoomIndex], WestAncor.transform.position, UniRooms[RoomIndex].transform.rotation);
            }
            if (RoomType == 1)
            {
                //A random room in the array is selected to be spawned and then is spawned
                RoomIndex = Random.Range(0, WestRooms.Length);
                Instantiate(WestRooms[RoomIndex], WestAncor.transform.position, WestRooms[RoomIndex].transform.rotation);
            }
            //the spawn anchor is deleted as it is no longer needed
            Destroy(WestAncor);
        }
    }
}
