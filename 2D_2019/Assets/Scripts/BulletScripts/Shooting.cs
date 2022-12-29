using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Character player;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject[] bulletPrefab;
    [SerializeField] float bulletForce = 20f;
    public float timeToAttack = 0.5f;
    [SerializeField] float destroyAfter = 1f;
    float timer = 0;

    private void Start()
    {
        player = GetComponent<Character>();
    }
    // Update is called once per frame
    void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }
        timer = 0;
        if (player.damageIncrease <= 10)
        {
            Shoot(0);
        }
        else if(player.damageIncrease <= 15)
        {
            Shoot(1);
        }
        else if (player.damageIncrease <= 20)
        {
            Shoot(2);   
        }
        else 
        { 
            Shoot(bulletPrefab.Length-1);
        }
    }
    
    private void Shoot(int i)
    {
        
        GameObject bullet = Instantiate(bulletPrefab[i], firePoint.position, firePoint.rotation); 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, destroyAfter);
    }
    
}
