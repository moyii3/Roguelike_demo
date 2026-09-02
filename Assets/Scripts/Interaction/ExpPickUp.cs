using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickUp : MonoBehaviour, IPickUpObject
{
    [SerializeField] int expAmout;
    public void OnPickUp(Character character)
    {
        character.GetComponent<Level>().AddExperience(expAmout);
    }
}
