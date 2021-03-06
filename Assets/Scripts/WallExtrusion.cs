﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallExtrusion : MonoBehaviour
{
    Material wallExtrusionMaterial;
    public float height = 10;
    GameObject cube;
    public int whichFloorRUOn;
    GameObject floor1;
    GameObject floor2;
    GameObject floor3;

    void Start()
    {
        //floor1 = GameObject.Find("floor1"); //we don't have floor1 yet
        floor2 = GameObject.Find("floor2");
        floor3 = GameObject.Find("floor3");

        wallExtrusionMaterial = Resources.Load("Wall Extrusion Material", typeof(Material)) as Material;
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(transform.position.x, transform.position.y, +height / 2);
        cube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, height);
        cube.layer = 11;
        //cube.transform.parent = this.transform;

        if (whichFloorRUOn == 2)
        {
            cube.transform.parent = floor2.transform; //set it to be a child of the obstacle
        }
        else if (whichFloorRUOn == 3)
        {
            cube.transform.parent = floor3.transform; //set it to be a child of the obstacle
        }
        cube.GetComponent<MeshRenderer>().material = wallExtrusionMaterial;
    }

    private void Update()
    {
        cube.transform.position = new Vector3(transform.position.x, transform.position.y, +height / 2);
        cube.transform.rotation = transform.rotation;
    }
}
