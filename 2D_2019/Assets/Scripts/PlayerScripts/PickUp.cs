using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] int exprienceReward = 200;
    [SerializeField] int coinReward = 100;
    [SerializeField] int HP = 3;
    [SerializeField] GameObject colectEffect;
    [SerializeField] Item item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "player")
        {
            GameObject effect = Instantiate(colectEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if(gameObject.tag == "exp")
            {
                GameObject.FindGameObjectWithTag("player").GetComponent<Level>().AddExprience(exprienceReward);
            }
            if (gameObject.tag == "coin")
            {
                GameObject.FindGameObjectWithTag("player").GetComponent<Character>().getCoins(coinReward);
            }
            if (gameObject.tag == "heart")
            {
                GameObject.FindGameObjectWithTag("player").GetComponent<Character>().AddHealth(HP);
            }
            if (gameObject.tag == "item")
            {
                GameObject.FindGameObjectWithTag("player").GetComponent<PassiveItems>().Equip(item);
            }
            Destroy(effect, 0.3f);

        }
    }
    
}
