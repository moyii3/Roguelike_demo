using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject dropItemPrefab;
    [SerializeField] [Range(0f, 1f)] float chance = 1f;

    bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void OnDestroy()
    {
        if (!isQuitting)
        {
            if(Random.value < chance)
            {
                Transform t = Instantiate(dropItemPrefab).transform;
                t.position = transform.position;
            }    
        }
        

    }
}
