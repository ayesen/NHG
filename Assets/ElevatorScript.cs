using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public Vector3 floor1;
    public Vector3 floor2;
    public Vector3 floor3;
    public GameObject player;
    public float moveSpd;

    private Vector3 movePos;
    private Vector3 playerMovePos;
    private Vector3 destination;
    private Vector3 playerMoveDistance;

    // Start is called before the first frame update
    void Start()
    {
        destination = floor2;
        movePos = floor2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            destination = floor3; // set destination to floor3
            playerMoveDistance = destination - player.GetComponent<Transform>().position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            destination = floor2; // set destination to floor2
            playerMoveDistance = destination - player.GetComponent<Transform>().position;
        }
        transform.position = movePos;

        movePos = Vector3.MoveTowards(movePos, destination, moveSpd * Time.deltaTime);

        //movePos.x = Mathf.Lerp(movePos.x, destination.x, moveSpd * Time.deltaTime); // lerp to the destination
        //movePos.y = Mathf.Lerp(movePos.y, destination.y, moveSpd * Time.deltaTime);

        //if (player.GetComponent<PlayerMove>().cantMove && (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha2))) // if player is on the elevator and key is pressed
        //{
        //    player.GetComponent<Transform>().position = playerMovePos;
        //    player.transform.position = playerMovePos;
        //    playerMovePos = Vector3.MoveTowards(playerMovePos, destination - playerMovePos, moveSpd * Time.deltaTime);
           
        //}
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
