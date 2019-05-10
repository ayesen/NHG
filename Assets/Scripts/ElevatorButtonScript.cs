using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorButtonScript : MonoBehaviour
{
    public ElectricityScript es;
    public GameObject leftDoor;
    public GameObject rightDoor;
    public newElevatorScript els;
    public Text fInteraction;

    public Vector3 leftDoorOpenPos;
    public Vector3 rightDoorOpenPos;
    public Vector3 leftDoorClosedPos;
    public Vector3 rightDoorClosedPos;
    public float openSpd;

    Vector3 leftDoorTarget;
    Vector3 rightDoorTarget;
    bool flag;

    // Start is called before the first frame update
    void Start()
    {
        leftDoorTarget = leftDoor.transform.position;
        rightDoorTarget = rightDoor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            if (es.on && Input.GetKeyDown(KeyCode.E))
            {
                // open door
                leftDoorTarget = leftDoorOpenPos;
                rightDoorTarget = rightDoorOpenPos;
                SoundManager.me.ButtonPressedSound(transform.position);
                SoundManager.me.EleDoorOpen(rightDoorOpenPos);
            }
            else if (!es.on && Input.GetKeyDown(KeyCode.E))
            {
                fInteraction.text = "Elevator Not Powered";
                SoundManager.me.FailedElectricSound(transform.position);
                //print("not powered");
            }
        }

        leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, leftDoorTarget, openSpd * Time.deltaTime);
        rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, rightDoorTarget, openSpd * Time.deltaTime);
        if (newElevatorScript.girlInside)
        {
            leftDoorTarget = leftDoorClosedPos;
            rightDoorTarget = rightDoorClosedPos;
            //SoundManager.me.EleDoorClose(rightDoorClosedPos);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fInteraction.text = "Press E to Push Button ";
            flag = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fInteraction.text = " ";
            flag = false;
        }
    }
}
