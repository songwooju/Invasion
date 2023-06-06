using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    int level;

    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.FloorToInt(GameManager.instance.gameTime / 15.0f);

        if (timer > (level == 0 ? 0.5f : 1f))
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(level);
        if (enemy != null)
        {
            Transform spawnTransform = spawnPoint[Random.Range(1, spawnPoint.Length)];
            if (spawnTransform != null)
            {
                enemy.transform.position = spawnTransform.position;
            }
        }
    }
}