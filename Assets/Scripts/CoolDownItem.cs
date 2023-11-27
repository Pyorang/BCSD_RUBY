using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownItem : MonoBehaviour
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
            other.GetComponent<RubyMove>().prepareBullet *= 4.25f/5.0f;
            Destroy(gameObject);
        }
    }
}
