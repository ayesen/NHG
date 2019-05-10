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
    public EnemyTargetSetter eneScript;
    public PlayerMove plaScript;
    public bool gameEnd;
    AudioSource deathSound;
    bool soundFlag;
    // Update is called once per frame
    private void Start()
    {
        deathSound = GetComponent<AudioSource>();
        soundFlag = true;
    }

    void Update()
    {
        if (gameEnd)
        {
            playDeathSound();
        }
        if(gameEnd && Input.GetKeyDown(KeyCode.R))
        {
            youDie.enabled = false;
            contour.enabled = false;
            eneScript.enabled = true;
            plaScript.enabled = true;
            SoundManager.me.enabled = true;
            SceneManager.LoadScene(0);
        }

    }

    void playDeathSound()
    {
        if (soundFlag)
        {
            youDie.enabled = true;
            contour.enabled = true;
            eneScript.enabled = false;
            plaScript.enabled = false;
            SoundManager.me.enabled = false;
            fInteraction.text = "Press R to Restart";
            deathSound.Play();
            soundFlag = false;
        }
        
    }
}
