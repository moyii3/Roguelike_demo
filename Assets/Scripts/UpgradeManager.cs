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
        foreach(var upgradeData in upgradeDatas)
        {
            upgradeData.SetUp(upgradeSOs[(int)Random.Range(0,4)]);
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
                break;
            case UpgradeSO.UpgradeType.attackSpeed:
                break;
        }
        UpgradeSelectionPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
