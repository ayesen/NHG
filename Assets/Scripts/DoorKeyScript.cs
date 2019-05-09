using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //player.GetComponent<PlayerMove>().promptMSG = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                
            }
            
        }
    }
}
