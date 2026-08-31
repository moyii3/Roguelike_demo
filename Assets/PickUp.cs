using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] int healAmount;

    private void OnTriggerEnter(Collider other)
    {
        Character c = other.GetComponent<Character>();
        if(c != null)
        {
            c.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
