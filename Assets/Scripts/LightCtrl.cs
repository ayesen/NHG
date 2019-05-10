using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightCtrl : MonoBehaviour
{
    public bool on;
    public bool roomSealed = false;
    bool playerInZone = false;
    bool enemyInZone = false;
    public GameObject[] enemy;
    public Text fInteraction;
    bool open;

    // Start is called before the first frame update
    void Start()
    {
        if (!on)
        {
            GetComponent<FieldOfViewForLightSources>().viewAngle = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i].GetComponent<KillTheGirl>().killing)
            {
                this.enabled = false;
            }
        }

        if (playerInZone && Input.GetKeyDown(KeyCode.E) && !open)
        {
            SoundManager.me.LightOpen(transform.position);
            open = false;
        }

        if (playerInZone && Input.GetKeyDown(KeyCode.E) && open)
        {
            SoundManager.me.LightClose(transform.position);
            open = true;
        }

        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            on = !on;
            SoundManager.me.SwithOnLight(transform.position);
            GetComponent<FieldOfViewForLightSources>().viewAngle = on ? 360 : 0;
        }

        if (enemyInZone)
        {
            //on = false;
            SoundManager.me.LightClose(transform.position);
            //GetComponent<FieldOfViewForLightSources>().viewAngle = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInZone = true;
            fInteraction.text = "Press e to switch the light";

        }

        if (collision.tag == "Enemy" && !collision.GetComponent<KillTheGirl>().killing)
        {
            print("enemyInZone");
            enemyInZone = true;
            //collision.gameObject.SetActive(false); // disable enemy
            //GetComponent<FieldOfViewForLightSources>().viewAngle = 0; // disable self light
            //on = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInZone = false;
            fInteraction.text = " ";
        }

        if (collision.tag == "Enemy")
        {
            enemyInZone = false;
        }
    }

    
}
