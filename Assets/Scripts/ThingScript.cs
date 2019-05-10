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
    bool flag;

    private void Update()
    {
        if (flag)
        {
            //player.GetComponent<PlayerMove>().promptMSG = true;
            if (red && Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<PlayerMove>().red = true;
                fInteraction.text = "Red Fuse Obtained";
                InventoryScript.me.redFuse.enabled = !InventoryScript.me.redFuse.enabled;
            }
            else if (blue && Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<PlayerMove>().blue = true;
                fInteraction.text = "Blue Fuse Obtained";
                InventoryScript.me.blueFuse.enabled = !InventoryScript.me.blueFuse.enabled;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fInteraction.text = "Press E to Push Button ";
            flag = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fInteraction.text = " ";
            flag = false;
        }
    }
}
