using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public bool noWayOut = true;
    public int RoomNum; //tell the enemy which room it is in

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(noWayOut);
        if (door1.GetComponent<DoorOpen>().bNF == 1 || door2.GetComponent<DoorOpen>().bNF == 1)
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
            collision.GetComponent<StoreEnemyTarget>().enemyTarget.GetComponent<FollowPlayer>().roomSealed = true;
            collision.GetComponent<StoreEnemyTarget>().enemyTarget.GetComponent<FollowPlayer>().roomEnemyIsIn = RoomNum;
        }

        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMove>().roomPlayerIsIn = RoomNum;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<StoreEnemyTarget>().enemyTarget.GetComponent<FollowPlayer>().roomSealed = false;
        }
    }
}
