using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class SceneControl : MonoBehaviour
{
    GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController");
    }

    public void goToStart()
    {
        SceneManager.LoadScene("StartScene");
        gameManager.GetComponent<AudioSource>().clip = gameManager.GetComponent<GameControl>().audioBGM[0];
        gameManager.GetComponent<AudioSource>().Play();
    }

    public void goToGame()
    {
        SceneManager.LoadScene("GameScene");
        gameManager.GetComponent<AudioSource>().clip = gameManager.GetComponent<GameControl>().audioBGM[1];
        gameManager.GetComponent<AudioSource>().Play();
        gameManager.GetComponent<GameControl>().CurrentScore = 0;
    }

    public void goToEnd()
    {
        SceneManager.LoadScene("EndScene");
        gameManager.GetComponent<AudioSource>().clip = gameManager.GetComponent<GameControl>().audioBGM[2];
        gameManager.GetComponent<AudioSource>().Play();
        if(gameManager.GetComponent<GameControl>().HighScore < gameManager.GetComponent<GameControl>().CurrentScore)
            gameManager.GetComponent<GameControl>().HighScore = gameManager.GetComponent<GameControl>().CurrentScore;
    }
}
