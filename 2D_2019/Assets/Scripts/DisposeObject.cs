using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposeObject : MonoBehaviour
{
    // Start is called before the first frame update
    Transform playerTransform;
    float maxDistace = 25f;
    [SerializeField] float timeDispose = 10f;
    void Start()
    {
        playerTransform = GameManager.instance.playerTransform;
    }
    void Update()
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
