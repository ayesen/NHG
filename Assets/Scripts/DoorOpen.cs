using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float speedRotate;
    public float limitDegree;
    private bool openFlag;
    private bool girlWithin;
    private float degree;
    private float bNF = -1;
    public Transform myself;

    private void Start()
    {
        print(myself);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)&&girlWithin)
        {
            openFlag = true;
            bNF = -bNF;
        }
        RotateDoor(openFlag);
        myself.Rotate(0, 0, degree);

        //print(transform.rotation.eulerAngles.z);
        //print(openFlag);
    }

    public void RotateDoor(bool open)
    {
        if(bNF == 1)
        {
            if (transform.rotation.eulerAngles.z < limitDegree && openFlag)
            {
                degree = speedRotate * Time.deltaTime*bNF;
            }
            if(transform.rotation.eulerAngles.z > limitDegree)
            {
                openFlag = false;
                degree = 0;
            }
        }
        if(bNF == -1)
        {
            if (transform.rotation.eulerAngles.z > limitDegree-90 && openFlag)
            {
                degree = speedRotate * Time.deltaTime*bNF;
            }
            if (transform.rotation.eulerAngles.z < limitDegree -90)
            {
                openFlag = false;
                degree = 0;
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.tag == "Player")
        {
            girlWithin = true;
            //print(trigger.gameObject.name+"enter the area");
        }
        
    }

    public void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.tag == "Player")
        {
            girlWithin = false;
            openFlag = false;
            //print("exit the area");
        }
            
    }
}
