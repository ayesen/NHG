using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricityScript : MonoBehaviour
{
    public bool on = false;
    public string msg;
    public Text fInteraction;
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
                fInteraction.text = "Elevator on";
                on = true;
            }
            else if ((!PlayerMove.me.blue || !PlayerMove.me.red) && Input.GetKeyDown(KeyCode.E))
            {
                fInteraction.text = "Missing Fuse";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fInteraction.text = "Press E to Push Button ";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fInteraction.text = " ";
        }
    }
}
