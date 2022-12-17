using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce = 20f;
    [SerializeField] float timeToAttack = 0.5f;
    [SerializeField] float destroyAfter = 1f;
    float timer = 0;

    
    // Update is called once per frame
    void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }
        timer = 0;
        Shoot();
    }
    
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, destroyAfter);
    }
    
}
