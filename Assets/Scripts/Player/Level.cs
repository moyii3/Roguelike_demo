using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int level = 1;
    [SerializeField] int experience = 0;
    [SerializeField] ExperienceBar experienceBar;

    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    void Start()
    {
        experienceBar.UpdateExperienceBar(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
    }
    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceBar(experience, TO_LEVEL_UP);
    }

    private void CheckLevelUp()
    {
        if(experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
            experienceBar.SetLevelText(level);
        }
    }
}
