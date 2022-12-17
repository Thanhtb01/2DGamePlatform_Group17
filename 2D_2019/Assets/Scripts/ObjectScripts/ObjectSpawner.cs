using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] items;
    private float spawnRadius = 10f;
    [SerializeField] float time = 20f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAnObj());
    }
    
    IEnumerator SpawnAnObj()
    {
        Vector2 spawnPos = GameObject.FindGameObjectWithTag("player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(items[Random.Range(0, items.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnObj());
    }
    
    // Update is called once per frame

}
