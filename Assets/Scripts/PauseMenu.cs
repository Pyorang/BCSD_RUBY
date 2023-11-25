using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool menuOn;

    [SerializeField]
    private GameObject pauseMenuDialog;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) PausingGame();
    }

    public void clickPauseButton()
    {
        PausingGame();
    }

    public void PausingGame()
    {
        menuOn = !menuOn;
        if (menuOn) Time.timeScale = 0;
        else Time.timeScale = 1;
        pauseMenuDialog.SetActive(menuOn);
    }
}
