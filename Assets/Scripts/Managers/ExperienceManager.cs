using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager: Singleton<ExperienceManager>
{
    public Slider expBar;
    public Text levelText;

    public delegate void OnLevelUp(int level);
    public OnLevelUp onLevelUp;

    private int currentExp;
    private int currentLevel;

    public int Level
    {
        get { return currentLevel; }
    }

    void Start()
    {
        currentExp = 0;
        currentLevel = 1;
    }

    public void AddExp(int exp)
    {
        currentExp += exp;
        int level = currentLevel;
        currentLevel = ExperienceCalculator.GetLevel(currentExp);

        if (isLevelUp(level, currentLevel))
        {
            if (onLevelUp != null)
            {
                onLevelUp(currentLevel);
            }
        }

        UpdateState();
    }

    void UpdateState()
    {
        levelText.text = "Level" + currentLevel;
        expBar.value = ExperienceCalculator.GetPercentInToLevel(currentLevel, currentExp);
    }

    bool isLevelUp(int level, int currentLevel)
    {
        return currentLevel > level;
    }
}
