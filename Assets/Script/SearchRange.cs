using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SearchRange : MonoBehaviour
{
    // スケール
    public Vector3 currentScale;
    // スケール変更の速度
    float scaleSpeed = 2.0f;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Spread()
    {
        currentScale = transform.localScale;
        // 徐々に大きくする
        currentScale.x += scaleSpeed/5 * Time.deltaTime;
        currentScale.z += scaleSpeed * Time.deltaTime;
        // スケールを適用する
        transform.localScale = currentScale;
    }
}
