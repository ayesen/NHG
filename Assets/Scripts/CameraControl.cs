﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform player;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Vector3 x = new Vector3(player.position.x, player.position.y, 0);
        transform.position = x;
    }
}
