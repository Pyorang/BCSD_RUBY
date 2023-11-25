using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneScore : MonoBehaviour
{
    GameObject gameManager;
    GameControl gameControl;

    [SerializeField]
    private Text currentScore;
    [SerializeField]
    private Text highScore;

    private void Awake()
    {
        gameManager = GameObject.FindWithTag("GameController");
        gameControl = gameManager.GetComponent<GameControl>();
        currentScore.text = "ȹ�� ���� : " + gameControl.CurrentScore;
        highScore.text = "�ְ� ���� : " + gameControl.HighScore;
    }
}
