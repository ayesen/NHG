using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAnimation : MonoBehaviour
{
    public Animator thisAnimator;
    // Start is called before the first frame update
    void Start()
    {
        thisAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenCloset()
    {
        thisAnimator.SetBool("opened", true);
        thisAnimator.SetBool("openning", false);

    }

    public void CloseCloset()
    {
        thisAnimator.SetBool("closed", true);
        thisAnimator.SetBool("closing", false);
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("WTF");
        if (collision.tag == "Player")
        {
            if (thisAnimator.GetBool("closed") == true)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    thisAnimator.SetBool("openning", true);
                    thisAnimator.SetBool("closed", false);
                }
            }
            if (thisAnimator.GetBool("opened") == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    thisAnimator.SetBool("closing", true);
                    thisAnimator.SetBool("opened", false);


                }
            }
        }
    }
}

