using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    private int currentHealth;
    private int coin = 0;
    public int armor = 0;
    [SerializeField] ExprienceBar expBar;
    [SerializeField] HealthBar healthBar;
    LoseGame loseMenu;
    private void Awake()
    {
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        expBar.SetCoinText(coin);
        //loseMenu = new LoseGame();
    }
    public void getCoins(int amount)
    {
        coin += amount;
        expBar.SetCoinText(coin);
    }
    public void AddHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > 10)
        {
            currentHealth = 10;
        }
        healthBar.SetHealth(currentHealth);
    }
    public void TakeDamage(int damage)
    {
        ApplyArmor(ref damage);
        if (checkDie())
        {
            //loseMenu.Lose();
            Debug.Log("LOST");
            return;
        }
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if(damage < 0) { damage = 0; }
    }

    public bool checkDie()
    {
        if (currentHealth < 1)
        {
            return true;
        }
        return false;
    }
}
