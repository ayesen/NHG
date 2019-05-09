using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;
    public Vector3 currentMonster;
    public Vector3[] posInEachRoom;

    public bool roomSealed = true; // indicate if the room is cealed
    public bool activated = false; // indicate if the enemy has been irradiated

    public int roomEnemyIsIn = 0; // indicate which room the enemy is in

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentMonster = monster.transform.position;
        if (FieldOfView.on && !roomSealed && activated) // FieldOfView.on indicate whether the torchlight is on
        {
            transform.position = player.transform.position;
        }

        if (!FieldOfView.on)
        {
            transform.position = currentMonster;
        }

        if (player.GetComponent<PlayerMove>().roomPlayerIsIn == roomEnemyIsIn && FieldOfView.on && activated) // if player and enemy in the same room, the enemy is activated, and the torchligth is on, chase player
        {
            transform.position = player.transform.position;
        }
    }
}
