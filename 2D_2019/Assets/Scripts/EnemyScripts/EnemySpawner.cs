using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies; 
    private float spawnRadius = 8f;
    private float time = 1.0f;
    void Start()
    {
        StartCoroutine(SpawnAnEnemy());
        TimeController.instance.BeginTimer();
    }

    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = GameObject.FindGameObjectWithTag("player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        if (TimeController.instance.elapsedTime <= 60)
        {
            Instantiate(enemies[Random.Range(0, 2)], spawnPos, Quaternion.identity);
        }
        else if (TimeController.instance.elapsedTime <= 120)
        {
            Instantiate(enemies[Random.Range(0, 4)], spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        }
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
    
}
