using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y - 1.1f, transform.position.z);
    }
}
