using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperScript : MonoBehaviour
{
    public Text fInteraction;
    bool flag;
    public bool one;
    public bool two;
    public bool three;


    private void Update()
    {
        if (flag)
        {
            if(Input.GetKeyDown(KeyCode.E) && one)
            {
                SoundManager.me.PaperSound(transform.position);
                fInteraction.text = "Use elevator to get out ";
            }

            if (Input.GetKeyDown(KeyCode.E) && two)
            {
                SoundManager.me.PaperSound(transform.position);
                fInteraction.text = "Monsters love to chase and devour the light ";
            }
            if (Input.GetKeyDown(KeyCode.E) && three)
            {
                SoundManager.me.PaperSound(transform.position);
                fInteraction.text = "I will be your Ishmael, and I will call you Ahab ";
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            flag = true;
            fInteraction.text = "Press E to read the paper ";
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
