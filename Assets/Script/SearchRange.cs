using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SearchRange : MonoBehaviour
{
    // �X�P�[��
    Vector3 currentScale;
    // �傫���Ȃ�



    void Start()
    {
        currentScale = transform.localScale;
    }

    void Update()
    {
        
    }

    public void Spread()
    {
        // �X�P�[���ύX�̑��x
        float scaleSpeed = 1.0f;

        // ���X�ɑ傫������
        currentScale.x += scaleSpeed * Time.deltaTime;
        currentScale.y += scaleSpeed * Time.deltaTime;
        // �X�P�[����K�p����
        transform.localScale = currentScale;
    }
}
