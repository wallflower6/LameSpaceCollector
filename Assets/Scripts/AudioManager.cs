using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    static bool audioStarted = false;

    void Awake() 
    {
        if (!audioStarted) {
            gameObject.GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            audioStarted = true;
        }
    }
}
