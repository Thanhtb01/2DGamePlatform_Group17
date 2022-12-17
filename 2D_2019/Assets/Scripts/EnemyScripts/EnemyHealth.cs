using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    public int health = 100;
    //[SerializeField] GameObject hitEffect;
    public int damage = 2;
    [SerializeField] GameObject dropItemPrefab;
    [SerializeField] [Range(0f, 1f)] float chance = 1f;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(health < 0.01)
        {
            anim.SetBool("IsDead", true);
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            anim.SetBool("IsDead", false);
        }
    }
    void Die()
    {
        Destroy(gameObject);
        if (Random.value < chance)
        {
            Transform t = Instantiate(dropItemPrefab).transform;
            t.position = transform.position;
        }

    }
    // Update is called once per frame
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "bullet")
    //    {
    //        health -= 10;
    //        anim.SetTrigger("Hurt");
    //        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //        collision.GetComponent<Collider2D>().enabled = false;
    //        collision.GetComponent<SpriteRenderer>().enabled = false;
    //        Destroy(effect, 0.5f);
    //    }
    //    //if(collision.tag == "forceField")
    //    //{
    //    //    health -= 2;
    //    //    anim.SetTrigger("Hurt");
    //    //}
    //}
    
}
