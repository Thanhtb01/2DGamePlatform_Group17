using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public GameObject player;
    [SerializeField] ExprienceBar expBar;
    private void Awake()
    {
        instance = this;
    }
    public int getCoin()
    {
        return player.GetComponent<Character>().coin;
    }
    public int increaseDamage()
    {
        return player.GetComponent<Character>().damageIncrease;

    }
    public void IncreaseArmor()
    {
        player.GetComponent<Character>().armor++;
        FindObjectOfType<AudioManager>().Play("Updated");

    }
    public void IncreaseSpeed()
    {
        player.GetComponent<Movement>().speed++;
        FindObjectOfType<AudioManager>().Play("Updated");

    }
    public void IncreaseDamage()
    {
        player.GetComponent<Character>().damageIncrease+=5;
        FindObjectOfType<AudioManager>().Play("Updated");


    }
    public void IncreaseHealth()
    {
        player.GetComponent<Character>().maxHealth += 2;
        player.GetComponent<Character>().AddHealth(2);
        FindObjectOfType<AudioManager>().Play("Updated");

    }
    public void DecreaseCoin(int price)
    {
        player.GetComponent<Character>().coin -= price;
        expBar.SetCoinText(player.GetComponent<Character>().coin);
    }
    public void IncreaseSpeedAtk()
    {
        player.GetComponent<Shooting>().timeToAttack /= 1.1f;
        FindObjectOfType<AudioManager>().Play("Updated");

    }
    public void setActiveSkill1()
    {
        player.GetComponent<WeaponManager>().setForceFieldSkill();
    }
    public void setActiveSkill2()
    {
        player.GetComponent<WeaponManager>().setFrameSkill();
    }
}
