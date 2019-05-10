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

    public void Update()
    {
        if (flag)
        {
            if (Input.GetKeyDown(KeyCode.E)&&PlayerMove.me.blue && PlayerMove.me.red)
            {
                fInteraction.text = "Elevator on";
                on = true;
                SoundManager.me.ButtonPressedSound(transform.position);
            }
            else if ((!PlayerMove.me.blue || !PlayerMove.me.red) && Input.GetKeyDown(KeyCode.E))
            {
                fInteraction.text = "Missing Fuse";
                SoundManager.me.FailedElectricSound(transform.position);
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
