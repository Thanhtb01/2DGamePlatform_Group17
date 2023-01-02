using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Character : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    public int coin = 0;
    public int armor = 0;
    public int damageIncrease = 0;
    [SerializeField] ExprienceBar expBar;
    [SerializeField] HealthBar healthBar;
    [SerializeField] GameObject loseGameUI;
    CinemachineImpulseSource impulseSource;
    private void Start()
    {
        //loseGameUI.SetActive(false);
        impulseSource = GetComponent<CinemachineImpulseSource>();
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        expBar.SetCoinText(coin);
    }
    public void getCoins(int amount)
    {
        coin += amount;
        expBar.SetCoinText(coin);
    }
    public void AddHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
    public void TakeDamage(int damage)
    {
        ApplyArmor(ref damage);
        if (checkDie())
        {
            loseGameUI.SetActive(true);
            Time.timeScale = 0;
            return;
        }
        currentHealth -= damage;
        impulseSource.GenerateImpulse();
        FindObjectOfType<AudioManager>().Play("PlayerHurt");
        healthBar.SetHealth(currentHealth);
    }

    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if(damage < 0) { damage = 0; }
    }
    public bool checkDie()
    {
        if (currentHealth <= 1)
        {
            return true;
        }
        return false;
    }
}
