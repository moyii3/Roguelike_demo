using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Transform player;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            spawnEnemy();
            timer = spawnTimer;
        }
    }

    private void spawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();
        position += player.position;
        position.y = 0.5f;
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.transform.parent = transform;
    }

    Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if(UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.z = spawnArea.y * f;
        }
        else
        {
            position.z = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }
        return position;
    }
}
