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

    public void SetUpgradePanel()
    {
        Time.timeScale = 0f;
        RandomUpgrade();
        UpgradeSelectionPanel.SetActive(true);
    }
    public void RandomUpgrade()
    {
        int i = 0;
        int count = upgradeSOs.Count;
        foreach(var upgradeData in upgradeDatas)
        {
            int index = Random.Range(i, count);
            UpgradeSO t = upgradeSOs[i];
            upgradeSOs[i] = upgradeSOs[index];
            upgradeSOs[index] = t;
            upgradeData.SetUp(upgradeSOs[i]);
            i++;
        }
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
        }
        UpgradeSelectionPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
