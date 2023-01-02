using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame1()
    {
        SceneManager.LoadSceneAsync("Playgame");
        Time.timeScale = 1f;
    }
    public void PlayGame2()
    {
        SceneManager.LoadSceneAsync("MapGame2");
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    public void clickButton()
    {
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }
    public void BackButton()
    {
        FindObjectOfType<AudioManager>().Play("BackButton");
    }
}
