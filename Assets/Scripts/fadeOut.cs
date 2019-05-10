using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeOut : MonoBehaviour
{
    public SpriteRenderer BlackRender;
    public Color newColor;
    bool ispushed = false;

    // Start is called before the first frame update
    void Start()
    {
        BlackRender = GetComponent<SpriteRenderer>();
        newColor = BlackRender.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ispushed = true;
        }

            if (ispushed == true)
            {
            if (newColor.a<=1)
            {
                double count = Time.deltaTime;

                newColor.a += (float)count;

            }
        }
            BlackRender.color = newColor;
        if(newColor.a >= 1)
        {
            SceneManager.LoadScene("Room");
        }
    }
}
