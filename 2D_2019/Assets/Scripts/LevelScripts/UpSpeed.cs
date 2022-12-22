using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpSpeed : MonoBehaviour
{
    public void acction()
    {
        PlayerController.instance.IncreaseSpeed();

        LevelUpController.instance.ClosePanel();

    }

}
