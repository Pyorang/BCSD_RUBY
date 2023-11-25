using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int CurrentScore;
    public int HighScore;

    private static GameControl instance = null;
    public AudioClip[] audioBGM;
    private AudioSource audioSource;
    void Start()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioBGM[0];
            audioSource.Play();
        }
        else
        {
            Destroy(this.gameObject);
        }
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
}
