using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;
    [SerializeField] TMPro.TextMeshProUGUI timeCounter;
    private TimeSpan timePlaying;
    private bool timerGoing;
    public float elapsedTime;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timeCounter.text = "00 : 00";
        timerGoing = false;
        BeginTimer();
    }
    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }
    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm' : 'ss");
            timeCounter.text = timePlayingStr;
            yield return null;
        }
    }

    
}
