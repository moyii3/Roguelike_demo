using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;

public class OrbitWeaponManager : MonoBehaviour
{
    public Transform target;
    public GameObject weaponPrefab;
    public float radius = 1.5f;
    public float rotateSpeed = 180f;

    private readonly List<GameObject> weapons = new();
    private float angle;

    void Update()
    {
        angle += rotateSpeed * Time.deltaTime;
        Layout();
    }

    public void SetWeaponCount(int count)
    {
        while(weapons.Count < count)
        {
            weapons.Add(Instantiate(weaponPrefab,transform));
        }
        while(weapons.Count > count)
        {
            Destroy(weapons[weapons.Count - 1]);
            weapons.RemoveAt(weapons.Count - 1);
        }
    }

    private void Layout()
    {
        int count = weapons.Count;
        if(count == 0) return;

        float step = 360f / count;

        for(int i = 0; i < count; i++)
        {
            float a = (angle + step * i) * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Cos(a), 0, Mathf.Sin(a));
            weapons[i].transform.position = target.position + offset;
        }
    }
}
