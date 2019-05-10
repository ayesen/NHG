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
    bool open;
    bool flag;

    private void Update()
    {
        if (flag)
        {
            if (Input.GetKeyDown(KeyCode.E) && !open)
            {
                SoundManager.me.CabinetOpenSound(transform.position);
                open = false;
            }

            if (Input.GetKeyDown(KeyCode.E) && open)
            {
                SoundManager.me.CabinetCloseSound(transform.position);
                open = true;
            }

            //player.GetComponent<PlayerMove>().promptMSG = true;
            if (red && Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<PlayerMove>().red = true;
                fInteraction.text = "Red Fuse Obtained";
                InventoryScript.me.redFuse.enabled = true;
            }
            else if (blue && Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<PlayerMove>().blue = true;
                fInteraction.text = "Blue Fuse Obtained";
                InventoryScript.me.blueFuse.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fInteraction.text = "Press E to interact with Closet ";
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
