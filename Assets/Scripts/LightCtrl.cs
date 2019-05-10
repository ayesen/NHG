using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCtrl : MonoBehaviour
{
    public bool on = true;
    public bool roomSealed = false;
    bool playerInZone = false;
    bool enemyInZone = false;

    // Start is called before the first frame update
    void Start()
    {
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            on = !on;
            GetComponent<FieldOfViewForLightSources>().viewAngle = on ? 360 : 0;
        }

        if (enemyInZone)
        {
            on = false;
            GetComponent<FieldOfViewForLightSources>().viewAngle = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInZone = true;
        }

        if (collision.tag == "Enemy")
        {
            enemyInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInZone = false;
        }

        if (collision.tag == "Enemy")
        {
            enemyInZone = false;
        }
    }

    
}
