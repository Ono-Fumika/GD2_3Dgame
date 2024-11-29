using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // プレイヤーの座標
    public Transform player;
    // カメラとプレイヤーのオフセット
    Vector3 offset = new Vector3(0, 2.0f, -6.0f);

    void LateUpdate()
    {
        // カメラの位置をプレイヤーの位置に設定
        Vector3 desiredPosition = player.position + offset;
        transform.position = desiredPosition;
    }
}
