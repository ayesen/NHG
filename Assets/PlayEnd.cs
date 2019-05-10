using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEnd : MonoBehaviour
{
    public GameObject End;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndAnimation()
    {
        End.gameObject.SetActive(true);
    }
}
