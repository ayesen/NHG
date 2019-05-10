using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Image contour;
    public Text youDie;
    public Text fInteraction;
    AudioSource deathSound;
    // Update is called once per frame
    private void Start()
    {
        deathSound = GetComponent<AudioSource>();
    }

    void playDeathSound()
    {
            youDie.enabled = true;
            contour.enabled = true;
            deathSound.Play();
    }

    void loadScene()
    {
        
        
            youDie.enabled = false;
            contour.enabled = false;
            SceneManager.LoadScene(1);
        
    }
}
