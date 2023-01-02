using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpForceField : MonoBehaviour
{
    public bool updated = false;
    public void acction()
    {
        if (PlayerController.instance.getCoin() >= gameObject.GetComponent<UpdateLv>().optionUpdate.coin)
        {
            PlayerController.instance.setActiveSkill1();
            PlayerController.instance.DecreaseCoin(gameObject.GetComponent<UpdateLv>().optionUpdate.coin);
            updated = true;
        }
        if (updated == true)
        {
            LevelUpController.instance.ClosePanel();
        }
        else
        {
            LevelUpController.instance.setTextChooseFail();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LevelUpController.instance.ClosePanel();
            }
        }
    }
}
