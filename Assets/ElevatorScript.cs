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

    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            destination = floor3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            destination = floor2;
        }

    }
}
