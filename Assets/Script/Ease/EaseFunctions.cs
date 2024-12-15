using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseFunctions : MonoBehaviour
{
    public static float EaseInOutBack(float x)
    {
        float c1 = 1.70158f; 
        float c2 = c1 * 1.525f; 
        return x < 0.5f 
            ? (Mathf.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2 
            : (Mathf.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
    }
}
