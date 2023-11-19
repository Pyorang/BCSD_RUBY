using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneControl : MonoBehaviour
{

    public void goToStart()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void goToGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void goToEnd()
    {
        SceneManager.LoadScene("EndScene");
    }
}
