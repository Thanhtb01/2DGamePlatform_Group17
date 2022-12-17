using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] int damage = 10;
    private EffectShoot effect;
    [SerializeField] bool damageActive = false;
    private void Awake()
    {
        effect = GetComponent<EffectShoot>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            effect.ShootEffect();
            ForceFieldActive(collision);
            gameObject.GetComponent<Collider2D>().enabled = damageActive;
            gameObject.GetComponent<SpriteRenderer>().enabled = damageActive;
        }
        if(collision.tag == "forceground")
        {
            effect.ShootEffect();
            gameObject.GetComponent<Collider2D>().enabled = damageActive;
            gameObject.GetComponent<SpriteRenderer>().enabled = damageActive;
            if(damageActive == false)
            {
                Destroy(gameObject);
            }
        }
    }
    private void ForceFieldActive(Collider2D col)
    {
        col.GetComponent<EnemyHealth>().health -= damage;
        col.GetComponent<Animator>().SetTrigger("Hurt");
    }
}
