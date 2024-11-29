using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 壁
    public Wall wall;
    // サーチ範囲
    SearchRange searchRange;
    // 移動できるかのフラグ
    bool isMove = true;

    void Start()
    {
        
    }

    void Update()
    {
        // 移動
        if (isMove)
        {
            Move();
        }
        // 絵を描く
        if(wall != null)
        {
            DrawPaint();
        }
        
    }

    void Move()
    {
        // 移動スピード
        float moveSpeed = 3.0f;
        // 回転スピード
        float rotateSpeed = 5.0f;
        // 井戸家
        Vector3 moveDir = Vector3.zero;
        
        // 移動する
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveDir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveDir += Vector3.right;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveDir += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveDir += Vector3.back;
        }
        if(moveDir != Vector3.zero)
        {
            // 移動ベクトルを正規化
            moveDir.Normalize();
            transform.position += moveDir * moveSpeed * Time.deltaTime;
            // プレイヤーの方向を進行方向に向ける
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
        }
        

    }
    void DrawPaint()
    {
        if (wall != null)
        {
            // スペースを押したら
            if (Input.GetKey(KeyCode.Space))
            {
                // 移動をやめる
                isMove = false;
                // 絵を描くアニメーション

                // 壁から絵を描く関数を呼び出す
                wall.DrawPaint(true);
                // 範囲を大きくする
                searchRange.Spread();
            }
            // 離したら
            if (Input.GetKeyUp(KeyCode.Space))
            {
                // 壁から絵を描く関数を呼び出す
                wall.DrawPaint(false);
                // DrawColisionを消す
                wall.DrawColisionDestory();
                isMove = true;
                wall = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // DrawColisionに当たったら
        if (other.tag == "DrawColosion")
        {
            // 壁を判定する
            wall = other.transform.parent.GetComponent<Wall>();
            searchRange = wall.GetComponentInChildren<SearchRange>();

            if(searchRange == null)
            {
                Debug.Log("ない！");
            }
        }
    }

}
