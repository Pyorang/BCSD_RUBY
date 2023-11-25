using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    GameObject gameManager;
    GameControl gameControl;

    [SerializeField]
    private Text currentScore;

    private void Awake()
    {
        gameManager = GameObject.FindWithTag("GameController");
        gameControl = gameManager.GetComponent<GameControl>();
    }

    private void Update()
    {
        currentScore.text = "Score : " + gameControl.CurrentScore;
    }
}
