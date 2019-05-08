using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closetAnimation : MonoBehaviour
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
    }

    public void CloseCloset()
    {
        thisAnimator.SetBool("closed", true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("WTF");
        if(collision.tag == "Player")
        {
            if (thisAnimator.GetBool("closed") == true)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    thisAnimator.SetBool("openning", true);
                }
            }
            if (thisAnimator.GetBool("opened") == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    thisAnimator.SetBool("closing", true);

                }
            }
        }
    }
}
