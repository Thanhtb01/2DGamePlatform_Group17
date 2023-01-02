using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] boss;
    private float spawnRadius = 8f;
    private float time = 0f;
    void Start()
    {
        Debug.Log(TimeController.instance.elapsedTime);
        if (TimeController.instance.elapsedTime % 10 == 0)
        {
            StartCoroutine(SpawnABoss());
        }
        //TimeController.instance.BeginTimer();
    }
    private void Update()
    {
        Debug.Log(TimeController.instance.elapsedTime);
    }
    IEnumerator SpawnABoss()
    {
        Vector2 spawnPos = GameObject.FindGameObjectWithTag("player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(boss[Random.Range(0, boss.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        if(TimeController.instance.elapsedTime % 10 == 0)
        {
            StartCoroutine(SpawnABoss());
        }
    }
    
}
