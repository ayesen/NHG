using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WritingEffect : MonoBehaviour
{

    public float charsPerSecond;
    public float scrollSpeed;

    private string words;
    private bool isActive = false;
    private float timer;
    private Text myText;
    private RectTransform textBox;
    private int currentPos = 0;
    
    void Start()
    {
        timer = 0;
        isActive = true;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);
        myText = GetComponent<Text>();
        textBox = GetComponent<RectTransform>();
        words = myText.text;
        myText.text = "";
    }

    private void Update()
    {
        if (newElevatorScript.girlInside)
        {
            Scroll();
            OnStartWriter();
        }
        //Debug.Log (isActive);
    }

    void OnStartWriter()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {
                timer = 0;
                currentPos++;
                myText.text = words.Substring(0, currentPos - 1);
                if (currentPos >= words.Length)
                {
                    OnFinish();
                }
            }
        }
    }

    void OnFinish()
    {
        isActive = false;
        timer = 0;
        currentPos = 0;
        myText.text = words;
    }

    void Scroll()
    {
        textBox.position = new Vector3(textBox.position.x,textBox.position.y+scrollSpeed*Time.deltaTime);
    }
}
