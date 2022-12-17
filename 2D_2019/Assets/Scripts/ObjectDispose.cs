using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDispose : MonoBehaviour
{
    Transform playerTransform;
    float maxDistace = 25f;
    [SerializeField] float timeDispose = 10f;
    private void Start()
    {
        playerTransform = GameManager.instance.playerTransform;
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance > maxDistace)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 10f);
        }
    }
}
