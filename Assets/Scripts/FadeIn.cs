
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    public SpriteRenderer BlackRender;
    public Color newColor;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        BlackRender = GetComponent<SpriteRenderer>();
        newColor = BlackRender.color;
    }

    // Update is called once per frame
    void Update()
    {
        double count = Time.deltaTime * time;
        if (newColor.a > 0)
        {
            newColor.a -= (float)count;
        }
        BlackRender.color = newColor;

       
    }

}
