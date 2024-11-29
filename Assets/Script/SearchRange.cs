using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SearchRange : MonoBehaviour
{
    // スケール
    Vector3 currentScale;
    // 大きくなる



    void Start()
    {
        currentScale = transform.localScale;
    }

    void Update()
    {
        
    }

    public void Spread()
    {
        // スケール変更の速度
        float scaleSpeed = 1.0f;

        // 徐々に大きくする
        currentScale.x += scaleSpeed * Time.deltaTime;
        currentScale.y += scaleSpeed * Time.deltaTime;
        // スケールを適用する
        transform.localScale = currentScale;
    }
}
