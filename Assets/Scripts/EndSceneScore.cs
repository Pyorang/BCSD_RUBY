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
        currentScore.text = "È¹µæ Á¡¼ö : " + gameControl.CurrentScore;
        highScore.text = "ÃÖ°í Á¡¼ö : " + gameControl.HighScore;
    }
}
