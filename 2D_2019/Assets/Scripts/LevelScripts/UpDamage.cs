using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDamage : MonoBehaviour
{
    public void acction()
    {
        PlayerController.instance.IncreaseDamage();

        LevelUpController.instance.ClosePanel();
    }
}
