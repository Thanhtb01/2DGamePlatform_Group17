using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpController : MonoBehaviour
{
    public static LevelUpController instance;
    [SerializeField] GameObject lvPanel;
    public float timer = 0;
    private void Update()
    {
        if (timer < 3f)
        {
            timer += Time.deltaTime;
            return;
        }
    }
    private void Awake()
    {
        instance =  this;
    }
    public void ClosePanel()
    {
        lvPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void OpenPanel()
    {
        lvPanel.SetActive(true);
        Time.timeScale = 0f;
}
    
}
