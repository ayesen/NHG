using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorKeyScript : MonoBehaviour
{
    public bool goldenKeyCabinet;
    public bool silverKeyCabinet;
    public Text fInteraction;
    private bool flag;

    private void Update()
    {
        if (flag)
        {
            
                if (Input.GetKeyDown(KeyCode.E) && silverKeyCabinet)
                {
                    PlayerMove.me.silverKey = true;
                    fInteraction.text = "Silver Key Obtained";
                    InventoryScript.me.silverKey.enabled = !InventoryScript.me.silverKey.enabled;
                }
                else if (Input.GetKeyDown(KeyCode.E) && goldenKeyCabinet)
                {
                    PlayerMove.me.goldenKey = true;
                    fInteraction.text = "Golden Key Obtained";
                    InventoryScript.me.goldenKey.enabled = !InventoryScript.me.goldenKey.enabled;
                }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            flag = true;
            fInteraction.text = "Press E to interact with cabinet ";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            flag = false;
            fInteraction.text = " ";
        }
    }
}
