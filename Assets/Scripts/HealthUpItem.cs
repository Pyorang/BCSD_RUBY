using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpItem : MonoBehaviour
{
    private Rigidbody2D rigid;

    [SerializeField]
    private int speed;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RubyStat>().health += 1;
            if (other.GetComponent<RubyStat>().health > other.GetComponent<RubyStat>().MaxHealth)
                other.GetComponent<RubyStat>().health = other.GetComponent<RubyStat>().MaxHealth;
            other.GetComponent<RubyStat>().changeHealthBar();
            Destroy(gameObject);
        }
    }
}
