using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private static GameControl instance = null;
    public AudioClip audioBGM;
    private AudioSource audioSource;
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioBGM;
        audioSource.Play();
    }

    public static GameControl Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void gameExit()
    {
        Application.Quit();
    }
}
