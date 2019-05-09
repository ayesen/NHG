using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThingScript : MonoBehaviour
{
    public string msg;
    public GameObject player;
    public bool red;
    public bool blue;
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
            //player.GetComponent<PlayerMove>().promptMSG = true;
            if (red && Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<PlayerMove>().red = true;
                fInteraction.text = "Red Fuse Obtained";
            }
            else if (blue && Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<PlayerMove>().blue = true;
                fInteraction.text = "Blue Fuse Obtained";
            }
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        player.GetComponent<PlayerMove>().promptMSG = false;
    //    }
    //}

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
