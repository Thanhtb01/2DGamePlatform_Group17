using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseGame : MonoBehaviour
{
    //public static bool gameIsLose = false;
    [SerializeField] GameObject loseGameUI;
    private void Start()
    {
        loseGameUI.SetActive(false);
    }

    public void Lose()
    {
        loseGameUI.SetActive(true);
        Time.timeScale = 0f;
        TimeController.instance.EndTimer();
        //gameIsLose = true;
        gameObject.GetComponent<PauseMenu>().enabled = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Playgame");
        Time.timeScale = 1f;
        TimeController.instance.BeginTimer();

    }
    public void RestartGame2()
    {
        SceneManager.LoadScene("MapGame2");
        Time.timeScale = 1f;
        TimeController.instance.BeginTimer();

    }
}
