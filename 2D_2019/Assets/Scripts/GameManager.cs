using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    [SerializeField] GameObject winGameUI;
    private void Awake()
    {
        instance = this;
    }
    public Transform playerTransform;
    public void VictoryUI()
    {
        winGameUI.SetActive(true);
        Time.timeScale = 0;
    }
}
