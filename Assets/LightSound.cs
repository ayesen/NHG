using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSound : MonoBehaviour
{
    public AudioSource electric;
    // Start is called before the first frame update
    void Start()
    {
        electric = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    void PlaySound()
    {
        electric.Play();
    }

}
