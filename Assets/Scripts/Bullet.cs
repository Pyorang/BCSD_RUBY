using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigid;
    
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private float speed;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.right * speed;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<ClockManStat>().getHit();
            Destroy(gameObject);
        }
    }

}
