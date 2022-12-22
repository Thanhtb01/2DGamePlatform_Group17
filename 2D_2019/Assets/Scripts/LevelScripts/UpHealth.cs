using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpHealth : MonoBehaviour
{
    public void acction()
    {
        PlayerController.instance.IncreaseHealth();

        LevelUpController.instance.ClosePanel();

    }
}
