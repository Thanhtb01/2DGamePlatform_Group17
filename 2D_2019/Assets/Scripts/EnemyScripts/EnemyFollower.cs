using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    private List<Rigidbody2D> EnemyRBs;
    private SpriteRenderer sprite;
    [SerializeField] float speed = 0.5f;
    private Transform playerPos;
    private float repelRange = 1.5f;
    private Rigidbody2D rb;
    
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("player").transform;
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        if (EnemyRBs == null)
        {
            EnemyRBs = new List<Rigidbody2D>();
        }
        EnemyRBs.Add(rb);
    }
    private void OnDestroy()
    {
        EnemyRBs.Remove(rb);
    }


    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,playerPos.position) > 0.3f)
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        if (transform.position.x > playerPos.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        
    }
    private void FixedUpdate()
    {
        Vector2 repelForce = Vector2.zero;
        foreach (Rigidbody2D enemy in EnemyRBs)
        {
            if (enemy == rb)
            {
                continue;
            }
            if (Vector2.Distance(enemy.position, rb.position) <= repelRange)
            {
                Vector2 repelDir = (rb.position - enemy.position).normalized;
                repelForce += repelDir;
            }
        }
    }
}
 