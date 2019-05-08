using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newElevatorScript : MonoBehaviour
{
    public Vector3 currentFloor;
    public Vector3 floorStorage;
    public Vector3 targetPos3;
    public Vector3 targetPos2;
    public float moveSpd;

    public GameObject player;
    public GameObject floor1;
    public GameObject floor2;
    public GameObject floor3;

    // Start is called before the first frame update
    void Start()
    {
        targetPos3 = floor3.transform.position;
        targetPos2 = floor2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        floor3.transform.position = Vector3.MoveTowards(floor3.transform.position, targetPos3, moveSpd * Time.deltaTime);
        floor2.transform.position = Vector3.MoveTowards(floor2.transform.position, targetPos2, moveSpd * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("go to thrid floor");
            targetPos2 = floorStorage;
            targetPos3 = currentFloor;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("go to thrid floor");
            targetPos2 = currentFloor;
            targetPos3 = floorStorage;
        }
    }

    public void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.tag == "Player")
        {
            print("cargo in the ship");
            player.GetComponent<PlayerMove>().ready2Go = true;
        }
    }
}
