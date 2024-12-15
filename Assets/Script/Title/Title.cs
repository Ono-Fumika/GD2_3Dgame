using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    // 回転するかフラグ
    bool isRotate = false;
    // 回転する最大時間
    float rotateTime = 3.0f;
    // 今の時間
    float rotateTimer = 0;

    // 初期角度
    float initialYRotation;
    // 目標角度
    float targetYRotation = 2680f;

    TitleManeger titleManeger;

    void Start()
    {
        // 初期角度を保存
        initialYRotation = transform.eulerAngles.y;
    }

    void Update()
    {
        // フラグが立っていたら
        if (isRotate)
        {
            // タイマーを進める
            rotateTimer += Time.deltaTime;

            if (rotateTime > rotateTimer)
            {
                // 時間の進行度を計算
                float t = Mathf.Clamp01(rotateTimer / rotateTime);
                // イージング関数を使用して進行度を変換
                float easeT = EaseFunctions.EaseInOutBack(t);
                // 新しいY軸回転角度を計算
                float newYRotation = Mathf.Lerp(initialYRotation, targetYRotation, easeT);
                // Y軸回転を適用
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, newYRotation, transform.eulerAngles.z);
            }
            else
            {
                // シーン遷移を開始する
                Debug.Log("ゲームシーンに行くよ");
                titleManeger.ChangeScene();
            }


        }
    }

    public void SetRotate(TitleManeger titleManeger_)
    {
        titleManeger = titleManeger_;
        isRotate = true;
        rotateTimer = 0;
        initialYRotation = transform.eulerAngles.y;
    }
}
