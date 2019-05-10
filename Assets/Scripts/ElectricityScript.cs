using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricityScript : MonoBehaviour
{
    public bool on = false;
    public string msg;
    public Text fInteraction;
    public bool flag;
    bool open;

    public void Update()
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

            if (Input.GetKeyDown(KeyCode.E)&&PlayerMove.me.blue && PlayerMove.me.red)
            {
                fInteraction.text = "Elevator on";
                on = true;
                SoundManager.me.FailedElectricSound(transform.position);
                SoundManager.me.Rev(transform.position);
                InventoryScript.me.redFuse.enabled = false;
                InventoryScript.me.blueFuse.enabled = false;
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
            fInteraction.text = "Press E to Connect the Fuse";
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
