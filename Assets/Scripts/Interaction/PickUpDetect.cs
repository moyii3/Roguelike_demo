using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Character c = other.GetComponent<Character>();
        if(c != null)
        {
            GetComponent<IPickUpObject>().OnPickUp(c);
            Destroy(gameObject);
        }
    }
}
