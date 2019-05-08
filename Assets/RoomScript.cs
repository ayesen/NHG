using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public bool noWayOut = true; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(noWayOut);
        if (door1.GetComponent<DoorOpen>().bNF == 1 || door2.GetComponent<DoorOpen>().bNF == 1)
        {
            noWayOut = false;
        }
        else
        {
            noWayOut = true;
        }
    }
}
