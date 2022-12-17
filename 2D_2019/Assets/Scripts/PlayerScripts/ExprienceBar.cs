using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExprienceBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI levelText;
    [SerializeField] TMPro.TextMeshProUGUI coinText;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    public void UpdateExperienceSlider(int current, int target)
    {
        slider.maxValue = target;
        slider.value = current;
    }
    public void SetLevelText(int level)
    {
        levelText.text = "LEVEL: " + level.ToString();
    }
    public void SetCoinText(int coin)
    {
        coinText.text = "COIN: " + coin.ToString();
    }
}
