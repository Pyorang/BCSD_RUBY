using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuDialog : MonoBehaviour
{
    [SerializeField]
    private GameObject sceneManager;
    [SerializeField]
    private GameObject pauseMenu;

    public void clickGoMain()
    {
        pauseMenu.GetComponent<PauseMenu>().PausingGame();
        sceneManager.GetComponent<SceneControl>().goToStart();
    }

    public void clickCancel()
    {
        pauseMenu.GetComponent<PauseMenu>().PausingGame();
        gameObject.SetActive(false);
    }
}
