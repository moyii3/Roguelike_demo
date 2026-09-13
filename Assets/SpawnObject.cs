using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject toSpawn;
    [SerializeField] [Range(0f, 1f)] float posibility;

    public void Spawn()
    {
        if(Random.value < posibility)
        {
            GameObject go = Instantiate(toSpawn, transform.position, Quaternion.identity);
        }
    }
}
