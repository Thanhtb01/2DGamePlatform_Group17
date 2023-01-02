using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceFieldScript : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;
    public int damage = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            ForceFieldActive(collision);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (timer < timeToAttack)
            {
                timer += Time.deltaTime;
                return;
            }
            timer = 0;
            ForceFieldActive(collision);
        }
    }
    
    private void ForceFieldActive(Collider2D col)
    {
        Debug.Log(damage);
        col.GetComponent<EnemyHealth>().health -= (damage + PlayerController.instance.increaseDamage());
        col.GetComponent<Animator>().SetTrigger("Hurt");
    }
}
