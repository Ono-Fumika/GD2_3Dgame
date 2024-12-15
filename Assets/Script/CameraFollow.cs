using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // プレイヤーの座標
    public Transform player;
    // カメラとプレイヤーのオフセット
    Vector3 offset = new Vector3(0, 4.0f, -6.0f);
    // カメラの回転スピード
    //float rotationSpeed = 100.0f;

    void Update()
    {
        //float horizontalInput = Input.GetAxis("RightStickHorizontal");

        //// カメラの回転
        //if (horizontalInput != 0)
        //{ // カメラのオフセットを水平に回転させる
        //    Quaternion horizontalRotation = Quaternion.AngleAxis(horizontalInput * rotationSpeed * Time.deltaTime, Vector3.up);
        //    // オフセットを水平回転で更新
        //    offset = horizontalRotation * offset;
        //}
        //    Vector3 desiredPosition = player.position + offset;
        //transform.position = desiredPosition;
        // // カメラをプレイヤーの方向に向ける
        // transform.LookAt(player);

        //Debug.Log("RightStickHorizontal Input: " + horizontalInput);

        // カメラの位置をプレイヤーの位置に設定
        Vector3 desiredPosition = player.position + player.TransformDirection(offset);
        transform.position = desiredPosition;
        // カメラの回転をプレイヤーの回転に一致させる
        transform.rotation = Quaternion.Euler(9.5f, player.eulerAngles.y, 0);

    }
}
