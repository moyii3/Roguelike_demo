using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public GameObject UpgradeSelectionPanel;
    public List<UpgradeData> upgradeDatas;
    public List<UpgradeSO> upgradeSOs;
    public Character character;


    [SerializeField]
    private List<UpgradeSO> acquiredUpgrade = new();
    private int orbitWeaponCount = 0;


    public void SetUpgradePanel()
    {
        Time.timeScale = 0f;
        RandomUpgrade();
        UpgradeSelectionPanel.SetActive(true);
    }
    public void RandomUpgrade()
    {
        List<UpgradeSO> pool = new();

        //建立当前可获得的强化池
        foreach(var upgradeSO in upgradeSOs)
        {
            if(IsAvailable(upgradeSO))
                pool.Add(upgradeSO);
        }
        //随机抽取
        foreach(var upgradeData in upgradeDatas)
        {
            int index = Random.Range(0, pool.Count);
            upgradeData.SetUp(pool[index]);
            pool.RemoveAt(index);
        }


    }

    private bool IsAvailable(UpgradeSO upgradeSO)
    {
        //前置未满足
        if(upgradeSO.prerequisites != null)
        {
            foreach(var p in upgradeSO.prerequisites)
            {
                if(!acquiredUpgrade.Contains(p)) return false;
            }
        }

        //和已有强化互斥
        if(upgradeSO.exclusions != null)
        {
            foreach(var p in upgradeSO.exclusions)
            {
                if(acquiredUpgrade.Contains(p)) return false;
            }
        }

        return true;
    }

    public void ApplyUpgrade(UpgradeData upgradeData)
    {
        switch (upgradeData.upgradeSO.upgradeType)
        {
            case UpgradeSO.UpgradeType.strength:
                character.strength += upgradeData.upgradeSO.amount;
                break;
            case UpgradeSO.UpgradeType.defense:
                character.defense += upgradeData.upgradeSO.amount;
                break;
            case UpgradeSO.UpgradeType.speed:
                character.GetComponent<PlayerController>().moveSpeed += upgradeData.upgradeSO.amount;
                break;
            case UpgradeSO.UpgradeType.attackSpeed:
                character.GetComponentInChildren<WhipWeapon>().timeToAttack -= (upgradeData.upgradeSO.amount * 20) * 0.01f;
                break;
            case UpgradeSO.UpgradeType.triAttack:
                character.GetComponentInChildren<WhipWeapon>().triAttack = true;
                upgradeSOs.Remove(upgradeData.upgradeSO);
                break;
            case UpgradeSO.UpgradeType.OrbitWeapon:
                orbitWeaponCount += upgradeData.upgradeSO.amount;
                character.GetComponentInChildren<OrbitWeaponManager>().SetWeaponCount(orbitWeaponCount);
                break;
            case UpgradeSO.UpgradeType.OrbitSpeed:
                character.GetComponentInChildren<OrbitWeaponManager>().rotateSpeed *= upgradeData.upgradeSO.amount;
                break;
            case UpgradeSO.UpgradeType.OrbitRadius:
                character.GetComponentInChildren<OrbitWeaponManager>().radius *= upgradeData.upgradeSO.amount;
                break;
        }
        acquiredUpgrade.Add(upgradeData.upgradeSO);
        UpgradeSelectionPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
