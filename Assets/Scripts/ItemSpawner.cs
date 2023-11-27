using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private bool m_Spawned;

    [SerializeField]
    private GameObject[] ItemPrefab;
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
            SpawnItem();
            Invoke("CanSpawn", RespawnTime);
            spawnCount++;
        }
    }

    void SpawnItem()
    {
        Instantiate(ItemPrefab[Random.Range(0,2)], rigid.position + new Vector2(11f, Random.Range(-4f, 4f)), Quaternion.identity);
        m_Spawned = false;
        if (spawnCount == 7)
        {
            spawnCount = 0;
            RespawnTime *= 9.0f / 10.0f;
        }
    }

    void CanSpawn()
    {
        m_Spawned = true;
    }

}
