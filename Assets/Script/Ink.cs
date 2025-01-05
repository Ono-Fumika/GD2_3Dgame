using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ink : MonoBehaviour
{
    // インクの最大値
    float maxInk = 100.0f;
    // 現在のインク量
    public float currentInk = 0;
    // インクの初期値
    [SerializeField]
    float startInk;

    // バー
    [SerializeField] public Slider slider;

    void Start()
    {
        currentInk = startInk;
        slider.maxValue = maxInk;
        slider.value = startInk;
        
    }

    void Update()
    {
        
    }

    public void ReduceInk(float reduce_)
    {
        currentInk -= reduce_;
        slider.value = currentInk;
    }
}
