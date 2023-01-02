using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else { Pause(); }
        }
    }

     void Pause()
    {
        if(Time.timeScale != 0)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPause = true;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameObject.FindGameObjectWithTag("gui").GetComponent<AudioManager>().Play("ClickButton");

        GameIsPause = false;
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        GameObject.FindGameObjectWithTag("gui").GetComponent<AudioManager>().Play("ClickButton");


    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        GameObject.FindGameObjectWithTag("gui").GetComponent<AudioManager>().Play("ClickButton");

        Time.timeScale = 1f;
        GameIsPause = false;
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        GameObject.FindGameObjectWithTag("gui").GetComponent<AudioManager>().Play("ClickButton");


        Application.Quit();
    }
}
