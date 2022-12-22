using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpArmor : MonoBehaviour
{
    public void acction()
    {
        PlayerController.instance.IncreaseArmor();

        LevelUpController.instance.ClosePanel();


    }
}
