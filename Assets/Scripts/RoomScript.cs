using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    //public GameObject door1;
    //public GameObject door2;
    public GameObject[] doors;
    public bool noWayOut = true;
    public int RoomNum; //tell the enemy which room it is in

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int doorOpened = 0;
        //print(RoomNum);
        //print(noWayOut);
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].GetComponent<DoorOpen>().bNF == 1)
            {
                doorOpened++;
            }
        }
        if (doorOpened > 0)
        {
            noWayOut = false;
        }
        else
        {
            noWayOut = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && noWayOut) // if the enemy is inside the room and noWayOut is true, Enemy target stays inside the room
        {
            collision.GetComponent<StoreEnemyTarget>().enemyTarget.GetComponent<EnemyTargetSetter>().roomSealed = true;
            collision.GetComponent<StoreEnemyTarget>().enemyTarget.GetComponent<EnemyTargetSetter>().roomEnemyIsIn = RoomNum;
        }
        if (collision.tag == "Enemy" && !noWayOut)
        {
            collision.GetComponent<StoreEnemyTarget>().enemyTarget.GetComponent<EnemyTargetSetter>().roomSealed = false;
        }

        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMove>().roomPlayerIsIn = RoomNum;
        }

        if (collision.tag == "Light" && noWayOut)
        {
            collision.GetComponent<LightCtrl>().roomSealed = true;
        }
        if (collision.tag == "Light" && !noWayOut)
        {
            collision.GetComponent<LightCtrl>().roomSealed = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<StoreEnemyTarget>().enemyTarget.GetComponent<EnemyTargetSetter>().roomSealed = false;
        }
    }
}
