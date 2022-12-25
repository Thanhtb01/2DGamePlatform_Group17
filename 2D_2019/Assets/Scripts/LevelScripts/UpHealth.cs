using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpHealth : MonoBehaviour
{
    public void acction()
    {
        //if (PlayerController.instance.getCoin() > int.Parse(gameObject.GetComponent<UpdateLv>().coinOpt.ToString()))
        //{
        //    PlayerController.instance.IncreaseHealth();
        //    PlayerController.instance.DecreaseCoin(int.Parse(gameObject.GetComponent<UpdateLv>().coinOpt.ToString()));
        //}
        PlayerController.instance.IncreaseHealth();

        LevelUpController.instance.ClosePanel();

    }
}
