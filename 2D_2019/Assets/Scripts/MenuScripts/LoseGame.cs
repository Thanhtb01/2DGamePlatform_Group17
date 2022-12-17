﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseGame : MonoBehaviour
{
    //public static bool gameIsLose = false;
    [SerializeField] GameObject loseGameUI;
    
    public void Lose()
    {
        loseGameUI.SetActive(true);
        Time.timeScale = 0f;
        //gameIsLose = true;
        gameObject.GetComponent<PauseMenu>().enabled = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Playgame");

    }
}
