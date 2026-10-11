using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeData : MonoBehaviour
{
    public UpgradeSO upgradeSO;
    public TextMeshProUGUI name2;
    public TextMeshProUGUI description;

    public void SetUp(UpgradeSO upgradeSO)
    {
        this.upgradeSO = upgradeSO;
        name2.text = upgradeSO.name1;
        description.text = upgradeSO.description;
                
    }
}
