using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetSetter : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;
    public Vector3 currentMonster;
    //public Vector3[] posInEachRoom;
    public GameObject[] lightSources;
    GameObject closestLight;

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

        if (player.GetComponent<PlayerMove>().roomPlayerIsIn == roomEnemyIsIn && FieldOfView.on && activated) // if player and enemy in the same room, the enemy is activated, and the torchligth is on, chase player
        {
            transform.position = player.transform.position;
        }

        if (!FieldOfView.on && lightSources.Length>0 && activated) // if the flashlight is off and there is at least one light source
        {
            float ClosestDisToLight = 999999999;
            float disToLight = 0;
            print(disToLight);

            for (int i = 0; i < lightSources.Length; i++) // loop through all the light sources
            {
                disToLight = Vector3.Distance(monster.transform.position, lightSources[i].transform.position); // get the distance between enemy and light source
                print(disToLight);
                if (ClosestDisToLight > disToLight)  // if the distance is smaller than the current smallest one
                {
                    if (!lightSources[i].GetComponent<LightCtrl>().roomSealed && lightSources[i].GetComponent<LightCtrl>().on) // if the light source is not in a sealed room and it is on
                    {
                        ClosestDisToLight = disToLight;
                        closestLight = lightSources[i]; // set closestlight to this light source
                    }
                }
            }
            if (closestLight != null) // if there is a closestLight
            {
                transform.position = closestLight.transform.position; // enemy chase the light source
                if (disToLight < 0.5f) // if the enemy touched the light source
                {
                    monster.SetActive(false);// kill the enemy
                }
            }
            if (closestLight == null) // if there isn't a light source on and not in a sealed room
            {
                transform.position = currentMonster; // stay put
            }
        }
    }

    
}
