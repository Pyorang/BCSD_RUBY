using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool m_Spawned;

    [SerializeField]
    private GameObject ClockManPrefab;
    [SerializeField]
    private float RespawnTime;
    [SerializeField]
    private int spawnCount;

    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        m_Spawned = true;
        spawnCount = 0;
    }

    void Update()
    {
        if (m_Spawned)
        {
            SpawnEnemy();
            Invoke("CanSpawn", RespawnTime);
            spawnCount++;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(ClockManPrefab, rigid.position + new Vector2(11f, Random.Range(-3.5f, 3.5f)), Quaternion.identity);
        m_Spawned = false;
        if (spawnCount == 7)
        {
            spawnCount = 0;
            RespawnTime *= 9.75f / 10.0f;
        }
    }

    void CanSpawn()
    {
        m_Spawned = true;
    }
}
