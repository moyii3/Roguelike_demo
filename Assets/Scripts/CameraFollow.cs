using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 15f, -5f);
    public float smoothSpeed = 5f;
    void Start()
    {
        transform.position = target.position + offset;// 使相机位于距离玩家一定距离的位置

        transform.LookAt(target); // 使相机看向玩家
    }

    void FixedUpdate()
    {
        Vector3 desirePosition = target.position + offset; // 实时更新相机应该在的位置

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed * Time.fixedDeltaTime); // 平滑过渡到目标位置
        transform.position = smoothedPosition; // 更新相机位置

    }
}
