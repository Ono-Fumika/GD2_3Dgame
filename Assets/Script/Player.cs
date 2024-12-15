using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 壁
    Wall wall;
    // サーチ範囲
    SearchRange searchRange;
    // Mob
    public MOB targetMob;
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
        if (wall != null && targetMob == null)
        {
            DrawPaint();
        }
        // モブを変える
        if (targetMob != null && wall == null)
        {
            Debug.Log("モブに描けるよ"); // デバッグメッセージを追加

            // スペースを押したら
            if (Input.GetKey(KeyCode.Space) || (Input.GetButton("Fire1")))
            {
                MOB mob = targetMob;
                mob.ChangeAppearance();
            }
        }
    }
    void Move()
    {
        // 移動スピード
        float moveSpeed = 3.0f;

        // 左スティックの入力を取得
        float horizonal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // カメラの前方と右方向を基準に移動方向を計算
        Transform cameraTransform = Camera.main.transform; 
        Vector3 forward = cameraTransform.forward; 
        Vector3 right = cameraTransform.right; 
        // Y軸成分を無視して平面上での方向に変換
        forward.y = 0; 
        right.y = 0; 
        forward.Normalize(); 
        right.Normalize(); 
        // 入力に基づいて移動方向を決定
        Vector3 moveDir = forward * vertical + right * horizonal;
        if (moveDir != Vector3.zero)
        {
            // 移動ベクトルを正規化
            moveDir.Normalize();
            transform.position += moveDir * moveSpeed * Time.deltaTime;
            // プレイヤーの方向を進行方向に向ける
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
        }

    }
    void DrawPaint()
    {
        if (wall != null)
        {
            // スペースを押したら
            if (Input.GetKey(KeyCode.Space) || (Input.GetButton("Fire1")))
            {
                // 移動をやめる
                isMove = false;
                // 絵を描くアニメーション

                // 壁から絵を描く関数を呼び出す
                wall.DrawPaint(true, this);
                // 範囲を大きくする
                searchRange.Spread();
            }
            // 離したら
            if (Input.GetKeyUp(KeyCode.Space) || (Input.GetButtonUp("Fire1")))
            {
                // 壁から絵を描く関数を呼び出す
                wall.DrawPaint(false, this);
                // DrawColisionを消す
                wall.DrawColisionDestory();
                isMove = true;
                wall = null;
            }
        }
    }
    public void StopDraw()
    {
        // DrawColisionを消す
        wall.DrawColisionDestory();
        isMove = true;
        wall = null;
    }
    public void SetTarget(MOB search_)
    {
        targetMob = search_;
    }
    void OnCollisionEnter(Collision collision)
    {
        // DrawColisionに当たったら
        if (collision.transform.tag == "DrawColosion")
        {
            Debug.Log("絵を描けるよ"); // デバッグメッセージを追加

            // 壁を判定する
            wall = collision.transform.parent.GetComponent<Wall>();
            searchRange = wall.GetComponentInChildren<SearchRange>();
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());

            // ターゲットを壁にする
            targetMob = null;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        // DrawColosionから離れたら
        if (collision.transform.CompareTag("DrawColosion"))
        {
            wall = null;
            // 衝突を再度有効にする
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), false);
        }
    }
}
