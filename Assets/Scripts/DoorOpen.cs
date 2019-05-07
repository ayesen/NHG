using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float speedRotate;
    public float limitDegree;
    bool openFlag;
    float degree;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            openFlag = true;
        }

        RotateDoor(openFlag);

        transform.Rotate(0, 0, degree);

        //print(transform.rotation.eulerAngles.z);
        //print(openFlag);
    }

    public void RotateDoor(bool open)
    {
        if (transform.rotation.eulerAngles.z < limitDegree && openFlag)
        {
            degree = speedRotate * Time.deltaTime;
        }
        if(transform.rotation.eulerAngles.z > limitDegree)
        {
            openFlag = false;
            degree = 0;
        }

    }
}
