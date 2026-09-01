using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI levelText;

    public void UpdateExperienceBar(int curExp, int maxExp)
    {
        slider.value = ((float)curExp)/maxExp;      
    }

    public void SetLevelText(int level)
    {
        levelText.text = "等级：" + level.ToString() + "级";
    }
}
