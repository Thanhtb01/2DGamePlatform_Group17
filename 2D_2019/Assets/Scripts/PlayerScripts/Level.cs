using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] ExprienceBar expBar;
    int experience = 0;
    public int level = 1;
    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }
    private void Start()
    {
        expBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        expBar.SetLevelText(level);
        LevelUpController.instance.ClosePanel();
    }
    public void AddExprience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        expBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }
    public void CheckLevelUp()
    {
        expBar.SetLevelText(level);
        if (experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
            LevelUpController.instance.OpenPanel();
        }
    }
}
