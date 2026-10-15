using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitWeapon : MonoBehaviour
{
    private Character playerCharacter;
    [SerializeField] int damage;

    int FINAL_DAMAGE
    {
        get
        {
            return damage + playerCharacter.strength;
        }
    }

    void Start()
    {
        playerCharacter = GameManager.instance.playerTransfrom.GetComponent<Character>();
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if(damageable != null && other.tag != "Player")
        {
            damageable.TakeDamage(FINAL_DAMAGE);
        }
    }
}
