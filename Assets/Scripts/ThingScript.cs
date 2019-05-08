using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingScript : MonoBehaviour
{
    public string msg;
    public GameObject player;
    public bool red;
    public bool blue;

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
            }
            else if (blue && Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<PlayerMove>().blue = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //player.GetComponent<PlayerMove>().promptMSG = false;
        }
    }
}
