using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityScript : MonoBehaviour
{
    public bool on = false;
    public string msg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.E))//&&PlayerMove.me.blue && PlayerMove.me.red)
            {
                print("elevator on");
                on = true;
            }
            else if ((!PlayerMove.me.blue || !PlayerMove.me.red) && Input.GetKeyDown(KeyCode.E))
            {
                print("missing component");
            }
        }
    }
}
