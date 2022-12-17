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
    }
        
    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = GameObject.FindGameObjectWithTag("player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
    
}
