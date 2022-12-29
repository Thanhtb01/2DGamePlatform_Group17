using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDamage : MonoBehaviour
{
    public bool updated = false;

    public void acction()
    {
        if (PlayerController.instance.getCoin() >= gameObject.GetComponent<UpdateLv>().optionUpdate.coin)
        {
            PlayerController.instance.IncreaseDamage();
            PlayerController.instance.DecreaseCoin(gameObject.GetComponent<UpdateLv>().optionUpdate.coin);
            updated = true;
        }

        LevelUpController.instance.ClosePanel();

    }
}
