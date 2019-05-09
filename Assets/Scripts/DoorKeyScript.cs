using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorKeyScript : MonoBehaviour
{
    public bool goldenKeyCabinet;
    public bool silverKeyCabinet;
    public Text fInteraction;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && silverKeyCabinet)
            {
                PlayerMove.me.silverKey = true;
                fInteraction.text = "Silver Key Obtained";
            }
            else if (Input.GetKeyDown(KeyCode.E) && goldenKeyCabinet)
            {
                PlayerMove.me.goldenKey = true;
                fInteraction.text = "Golden Key Obtained";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fInteraction.text = "Press E to interact with cabinet ";
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
