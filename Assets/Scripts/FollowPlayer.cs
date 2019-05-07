using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;
    public Vector3 currentMonster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentMonster = monster.transform.position;
        if (FieldOfView.on)
        {
            transform.position = player.transform.position;
        }

        if (!FieldOfView.on)
        {
            transform.position = currentMonster;
        }
    }
}
