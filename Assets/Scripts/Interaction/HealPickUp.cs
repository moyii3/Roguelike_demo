using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUp : MonoBehaviour, IPickUpObject
{
    [SerializeField] int healAmount;

    public void OnPickUp(Character c)
    {
        c.Heal(healAmount);
    }
}
