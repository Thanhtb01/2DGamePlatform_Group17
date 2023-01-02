using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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
            if(gameObject.tag != "specialSkill")
            {
                FindObjectOfType<AudioManager>().Play("BulletExposion");

            }

        }
        if (collision.tag == "forceground")
        {
            effect.ShootEffect();
            gameObject.GetComponent<Collider2D>().enabled = damageActive;
            gameObject.GetComponent<SpriteRenderer>().enabled = damageActive;
            if (gameObject.tag != "specialSkill")
            {
                FindObjectOfType<AudioManager>().Play("BulletExposion");

            }

            if (damageActive == false)
            {
                Destroy(gameObject);
            }
        }
    }
    private void ForceFieldActive(Collider2D col)
    {
        col.GetComponent<EnemyHealth>().health -= (damage + PlayerController.instance.increaseDamage());

        col.GetComponent<Animator>().SetTrigger("Hurt");
    }
}
