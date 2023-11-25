using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RubyStat : MonoBehaviour
{ 
    public bool isRespawnTime;
    public int health;
    public int MaxHealth;

    BoxCollider2D m_collider;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    public float RespawnTime;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private GameObject Scenemanager;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = MaxHealth;
        changeHealthBar();
    }

    public void getHit()
    {
        health -= 1;
        changeHealthBar();

        Unbeatable();
        Invoke("Unbeatable", RespawnTime);

        if (health == 0)
        {
            Scenemanager.GetComponent<SceneControl>().goToEnd();
        }
    }

    public void changeHealthBar()
    {
        healthBar.fillAmount = ((float)health / (float)MaxHealth);
        healthText.text = health + " / " + MaxHealth;
    }

    void Unbeatable()
    {
        isRespawnTime = !isRespawnTime;

        if (isRespawnTime)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }
}
