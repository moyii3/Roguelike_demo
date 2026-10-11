using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UpgradeSO", menuName = "Game/Upgrade")]
public class UpgradeSO : ScriptableObject
{
    public enum UpgradeType
    {
        strength,
        defense,
        speed,
        attackSpeed
        
    }
    public string name1;
    public string description;
    public Sprite icon;
    public UpgradeType upgradeType;
    public int amount;
}
