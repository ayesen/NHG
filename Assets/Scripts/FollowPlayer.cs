using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;
    public Vector3 currentMonster;
    public Vector3[] posInEachRoom;

    public bool stay = true; // indicate whether the enemy stay still when the doors are closed or chase the player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentMonster = monster.transform.position;
        if (FieldOfView.on && !stay)
        {
            transform.position = player.transform.position;
        }

        if (!FieldOfView.on)
        {
            transform.position = currentMonster;
        }
        if (stay)
        {
            // need to get which room the enemy is in?
        }
    }
}
