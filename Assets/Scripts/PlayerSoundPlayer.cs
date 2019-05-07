using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWalkSound()
    {
        SoundManager.me.PlayerWalkSound(transform.position);
    }
}
