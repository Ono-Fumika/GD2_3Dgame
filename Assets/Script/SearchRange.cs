using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SearchRange : MonoBehaviour
{
    // �X�P�[��
    public Vector3 currentScale;
    // �X�P�[���ύX�̑��x
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
        // ���X�ɑ傫������
        currentScale.x += scaleSpeed/5 * Time.deltaTime;
        currentScale.z += scaleSpeed * Time.deltaTime;
        // �X�P�[����K�p����
        transform.localScale = currentScale;
    }
}
