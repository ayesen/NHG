using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallExtrusion : MonoBehaviour
{
    Material wallExtrusionMaterial;
    public float height = 10;
    GameObject cube;

    void Start()
    {
        wallExtrusionMaterial = Resources.Load("Wall Extrusion Material", typeof(Material)) as Material;
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(transform.position.x, transform.position.y, +height / 2);
        cube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, height);
        cube.layer = 11;
        cube.GetComponent<MeshRenderer>().material = wallExtrusionMaterial;
    }

    private void Update()
    {
        cube.transform.position = new Vector3(transform.position.x, transform.position.y, +height / 2);
        cube.transform.rotation = transform.rotation;
    }
}
