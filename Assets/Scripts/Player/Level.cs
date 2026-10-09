using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int level = 1;
    [SerializeField] int experience = 0;
    [SerializeField] ExperienceBar experienceBar;
    private Character  playCharacter;

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
        playCharacter = GameManager.instance.playerTransfrom.GetComponent<Character>();
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
            playCharacter.strength += level;
            playCharacter.defense += level;
            experienceBar.SetLevelText(level);
        }
    }
}
