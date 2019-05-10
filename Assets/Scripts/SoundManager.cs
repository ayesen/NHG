using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager me;
    public int maxAudioSources;
    AudioSource[] sources;
    public AudioSource sourcePrefab;
    public AudioClip[] playerStep;
    public AudioClip[] monsterStep;
    public AudioClip[] background;
    public AudioClip[] animalRoar;
    public AudioClip[] doorOpen;
    public AudioClip[] doorClose;
    public AudioClip[] elevator;//0 is open, 1 is close, 2 is short music,3 is long music 
    public AudioClip[] torchLight;//0 is open, 1 is close
    public AudioClip[] cabinet;//0 is open, 1 is close
    public Transform player;

    Vector3 playerPos;
    int lastPlayerWalk;
    int lastMonsterWalk;
    int lastMonsterRoar;
    int lastDoorClose;
    int lastDoorOpen;

    float roarTimer = 0;
    bool timerFlag = false;

    private void Awake()
    {
        if (me != null)//check me
        {
            Destroy(gameObject);
            return;
        }
        me = this;

        sources = new AudioSource[maxAudioSources];
        for (int i = 0; i < maxAudioSources; i++)
        {
            sources[i] = Instantiate(sourcePrefab, transform);
        }
    }

    private void Start()
    {
        sources[0].clip = background[0];
        sources[0].transform.position = player.position;
        sources[0].Play();
    }

    private void Update()
    {
        sources[0].transform.position = player.position;//BGM
        if (!sources[0].isPlaying)
        {
            sources[0].Play();
        }

        if (timerFlag)
        {
            roarTimer -= Time.deltaTime; 

            if (roarTimer < 0)
            {
                timerFlag = false;
            }
        }


    }

    public void PlayerWalkSound(Vector3 playerPosition)
    {
        int clipNum = GetRandom(playerStep.Length, lastPlayerWalk);
        lastPlayerWalk = PlaySound(playerStep, clipNum, playerPosition);
    }

    public void DoorCloseSound(Vector3 doorPosition)
    {
        int clipNum = GetRandom(doorClose.Length, lastDoorClose);
        lastDoorClose = PlaySound(doorClose, clipNum, doorPosition);
    }

    public void DoorOpenSound(Vector3 doorPosition)
    {
        int clipNum = GetRandom(doorOpen.Length, lastDoorOpen);
        lastDoorOpen = PlaySound(doorOpen, clipNum, doorPosition);
    }

    public void CabinetOpenSound(Vector3 cabinetPosition)
    {
        PlaySound(cabinet, 0, cabinetPosition);
    }

    public void EleDoorOpen(Vector3 eleDoor)
    {
        PlaySound(elevator, 0, eleDoor);
    }

    public void EleDoorClose(Vector3 eleDoor)
    {
        PlaySound(elevator, 1, eleDoor);
    }

    public void EleShortMusic(Vector3 eleDoor)
    {
        PlaySound(elevator, 2, eleDoor);
    }

    public void EleLongMusic(Vector3 eleDoor)
    {
        PlaySound(elevator, 3, eleDoor);
    }

    public void LightOpen(Vector3 torch)
    {
        PlaySound(torchLight, 0, torch);
    }

    public void LightClose(Vector3 torch)
    {
        PlaySound(torchLight, 1, torch);
    }

    public void MonsterRoarSound(Vector3 monsterPosition)
    {
        if (roarTimer < 0.1)
        {
            int clipNum = GetRandom(animalRoar.Length, lastMonsterRoar);
            lastMonsterRoar = PlaySound(animalRoar, clipNum, monsterPosition);
            timerFlag = true;
            roarTimer = 30;
        }
    }



    public void MonsterWalkSound(Vector3 monsterPosition)
    {

        int clipNum = GetRandom(monsterStep.Length, lastMonsterWalk);
        lastMonsterWalk = PlaySound(monsterStep, clipNum, monsterPosition);
    }



    int PlaySound(AudioClip[] clips, int clipNum, Vector3 pos)
    {
        AudioSource source = GetSource();
        source.clip = clips[clipNum];
        source.transform.position = pos;
        //source.pitch = Random.Range(.925f, 1.075f);
        source.Play();
        return clipNum;
    }

    AudioSource GetSource()
    {
        for (int i = 2; i < maxAudioSources; i++)//first 2 is for bgm
        {
            if (!sources[i].isPlaying)
            {
                return sources[i];
            }
        }
        Debug.LogError("NOT ENOUGH SOURCES");
        return sources[0];
    }

    int GetRandom(int clipNum, int lastPlayed)
    {
        int num = Random.Range(0, clipNum);
        int timesTried = 0;
        while (num == lastPlayed)
        {
            timesTried++;
            num = Random.Range(0, clipNum);
            if (timesTried > 500)
            {
                Debug.LogError("YOU DONT HAVE ENOUGH SOUNDS AND EVERYTHING IS GONNA BREAK FOR THE REST OF YOUR LIFE");
                break;
            }
        }
        return num;
    }

}
