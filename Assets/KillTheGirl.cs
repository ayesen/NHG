using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTheGirl : MonoBehaviour
{
    public Animator monsterAnimator;
    public GameObject girl;

    Vector3 girlpos;
    bool isPushed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPushed == true)
        {
            girl.transform.position = girlpos;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isPushed = true;
            girlpos = girl.transform.position;

            monsterAnimator.SetBool("Grab", true);
  
            collision.GetComponent<PlayerMove>().enabled = false;



            Debug.Log("hehe");

        }
    }


}
