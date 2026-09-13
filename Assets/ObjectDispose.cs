using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDispose : MonoBehaviour
{
    Transform playerTransfrom;
    float maxDistance = 40f;

    void Start()
    {
        playerTransfrom = GameManager.instance.playerTransfrom;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransfrom.position);
        if(distance > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
