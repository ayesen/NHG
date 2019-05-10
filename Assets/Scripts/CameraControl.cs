using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;

    public float limit = 10;
    public float scrollSpd = 0.5f;
    public Vector3 endScenePos;
    Vector3 camCurrentPos;

    void Update()
    {
        if (!newElevatorScript.girlInside)
            follow();
        else
            shift();
    }

    void follow()
    {
        Vector3 x = new Vector3(player.position.x, player.position.y, 0);
        transform.position = x;
    }

    void shift()
    {
        camCurrentPos = transform.position;

        camCurrentPos.y = Mathf.Lerp(camCurrentPos.y, endScenePos.y, scrollSpd * Time.deltaTime);
        camCurrentPos.x = Mathf.Lerp(camCurrentPos.x, endScenePos.x, scrollSpd * Time.deltaTime);

        transform.position = camCurrentPos;
        //if (limit > 0)
        //{
        //    Vector3 x = new Vector3(player.position.x - scrollSpd * Time.deltaTime, player.position.y, 0);
        //    transform.position = x;
        //    limit -= scrollSpd;
        //    print(limit);
        //}

    }
}
