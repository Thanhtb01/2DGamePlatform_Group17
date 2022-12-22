using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] GameObject player;
    
    private void Awake()
    {
        instance = this;
    }
    public int increaseDamage()
    {
        return player.GetComponent<Character>().damageIncrease;
    }
    public void IncreaseArmor()
    {
        player.GetComponent<Character>().armor++;
    }
    public void IncreaseSpeed()
    {
        player.GetComponent<Movement>().speed++;
    }
    public void IncreaseDamage()
    {
        player.GetComponent<Character>().damageIncrease+=5;
    }
    public void IncreaseHealth()
    {
        player.GetComponent<Character>().maxHealth += 2;
        player.GetComponent<Character>().AddHealth(2);
    }
}
