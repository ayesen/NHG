using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpen : MonoBehaviour
{
    public float speedRotate;
    public float limitDegree;
    public Text fInteraction;
    private bool openFlag;
    private bool girlWithin;
    private float degree;
    public float bNF = -1; // 1: opened -1: closed
    private string interWords;
    public Transform myself;
    public bool silverKeyDoor;
    public bool goldenKeyDoor;

    private void Start()
    {
        //print(myself);
        fInteraction.text = "LeftClick to Turn Off/On the Light Torch";
    }

    void Update()
    {
        if (silverKeyDoor)
        {
            if (Input.GetKeyDown(KeyCode.E) && girlWithin && !PlayerMove.me.silverKey)
            {
                interWords = "You need a silver key";
                fInteraction.text = interWords;
            }

            if (Input.GetKeyDown(KeyCode.E)&&girlWithin&&PlayerMove.me.silverKey)
            {
                openFlag = true;
                bNF = -bNF;
                if (bNF == 1)
                {
                         SoundManager.me.DoorOpenSound(transform.position);
                }
                if (bNF == -1)
                {
                    SoundManager.me.DoorCloseSound(transform.position);
                }
            }   
        }else if (goldenKeyDoor)
        {
            if (Input.GetKeyDown(KeyCode.E) && girlWithin && !PlayerMove.me.goldenKey)
            {
                interWords = "You need a golden key";
                fInteraction.text = interWords;
            }

            if (Input.GetKeyDown(KeyCode.E) && girlWithin && PlayerMove.me.goldenKey)
            {
                openFlag = true;
                bNF = -bNF;
                if (bNF == 1)
                {
                    SoundManager.me.DoorOpenSound(transform.position);
                }
                if (bNF == -1)
                {
                    SoundManager.me.DoorCloseSound(transform.position);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && girlWithin)
            {
                openFlag = true;
                bNF = -bNF;
                if (bNF == 1)
                {
                    SoundManager.me.DoorOpenSound(transform.position);
                }
                if (bNF == -1)
                {
                    SoundManager.me.DoorCloseSound(transform.position);
                }
            }
        }
        RotateDoor(openFlag);
        myself.Rotate(0, 0, degree);
    }

    public void RotateDoor(bool open)
    {
        if(bNF == 1)
        {
            if (transform.rotation.eulerAngles.z < limitDegree && openFlag)
            {
                degree = speedRotate * Time.deltaTime*bNF;
            }
            if(transform.rotation.eulerAngles.z > limitDegree)
            {
                openFlag = false;
                degree = 0;
            }
        }
        if(bNF == -1)
        {
            if (transform.rotation.eulerAngles.z > limitDegree-90 && openFlag)
            {
                degree = speedRotate * Time.deltaTime*bNF;
            }
            if (transform.rotation.eulerAngles.z < limitDegree -90)
            {
                openFlag = false;
                degree = 0;
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.tag == "Player")
        {
            girlWithin = true;
            interWords = "Press E";
            fInteraction.text = interWords;
            
            //print(trigger.gameObject.name+"enter the area");
        }
        
    }

    public void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.tag == "Player")
        {
            girlWithin = false;
            openFlag = false;
            interWords = " ";
            fInteraction.text = interWords;
            //print("exit the area");
        }
            
    }
}
