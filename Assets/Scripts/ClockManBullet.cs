using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManBullet : MonoBehaviour
{
    Rigidbody2D rigid;

    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject Ruby;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 StartLocation = rigid.transform.position;
        Ruby = GameObject.FindWithTag("Player");
        Vector3 dist = StartLocation - new Vector2(Ruby.transform.position.x, Ruby.transform.position.y+0.5f);
        rigid.velocity = dist.normalized * speed * (-1);
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!other.GetComponent<RubyStat>().isRespawnTime)
            {
                other.GetComponent<RubyStat>().getHit();
                Destroy(gameObject);
            }
        }
    }
}
