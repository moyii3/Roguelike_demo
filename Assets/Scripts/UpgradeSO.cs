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
        attackSpeed,
        triAttack,
        OrbitWeapon,
        OrbitSpeed,
        OrbitRadius,
        EnemyExplosion
        
    }
    public string name1;
    public string description;
    public Sprite icon;
    public UpgradeType upgradeType;
    public int amount;

    [Header("解锁前置条件")]
    public UpgradeSO[] prerequisites;

    [Header("互斥强化")]
    public UpgradeSO[] exclusions;
}
