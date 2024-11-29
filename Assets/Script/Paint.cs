using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    // フェードにかかる総時間
    float fadeDuration = 3.0f;
    // 今の経過時間
    float elapsedTime = 0.0f;
    // マテリアルを参照
    Material material;
    // 変更する色
    Color color;

    // アルファ値変えるフラグ
    bool isDraw = false;

    void Start()
    {
        // マテリアルを取得
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDraw)
        {
            if (elapsedTime < fadeDuration)
            {
                // タイマーを進める
                elapsedTime += Time.deltaTime;
                // アルファ値を更新
                color = material.color;
                color.a = Mathf.Clamp01(elapsedTime / fadeDuration); ;
                material.color = color;
            }
            // 絵を描き終わったら
            else
            {
                // 絵を描くモードをやめる
                
            }
        }
    }

    public void Draw(bool isDraw_)
    {
        isDraw = isDraw_;
    }
}
