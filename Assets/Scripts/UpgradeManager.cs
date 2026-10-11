using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public GameObject UpgradeSelectionPanel;
    public List<UpgradeData> upgradeDatas;
    public List<UpgradeSO> upgradeSOs;

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
}
