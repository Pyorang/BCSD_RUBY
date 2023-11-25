using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockManStat : MonoBehaviour
{
    [SerializeField]
    private int Maxhealth;
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private int score;

    public int health;

    private void Start()
    {
        health = Maxhealth;
        changeHealthBar();
    }


    public void getHit()
    {
        health -= 1;
        changeHealthBar();

        if (health == 0)
        {
            Destroy(gameObject);
            GameObject gameManager = GameObject.FindWithTag("GameController");
            gameManager.GetComponent<GameControl>().CurrentScore += score;
        }
    }

    public void changeHealthBar()
    {
        healthBar.value = (float)health / (float)Maxhealth;
    }
}
