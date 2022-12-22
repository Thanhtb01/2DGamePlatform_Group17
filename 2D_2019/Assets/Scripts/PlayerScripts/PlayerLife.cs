using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Character character;


    private bool hit = true;
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
        character = GetComponent<Character>();
    }
    IEnumerator HitBoxOff()
    {
        hit = false;
        yield return new WaitForSeconds(1.5f);
        hit = true;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            
            if (hit)
            {
                StartCoroutine(HitBoxOff());
                character.TakeDamage(collision.GetComponent<EnemyHealth>().damage);
                anim.SetBool("Hit", true);
            }
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (hit)
            {
                StartCoroutine(HitBoxOff());
                character.TakeDamage(collision.GetComponent<EnemyHealth>().damage);
                anim.SetBool("Hit", true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            anim.SetBool("Hit", false);
        }
    }
}
