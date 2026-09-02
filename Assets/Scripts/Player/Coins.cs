using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] int coinAquired = 0;
    [SerializeField] TMPro.TextMeshProUGUI coinsCountText;

    public void Add(int count)
    {
        coinAquired += count;
        coinsCountText.text = "Coins：" + coinAquired.ToString();
    }
}
