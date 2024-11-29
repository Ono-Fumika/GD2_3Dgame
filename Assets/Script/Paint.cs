using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    // �t�F�[�h�ɂ����鑍����
    float fadeDuration = 3.0f;
    // ���̌o�ߎ���
    float elapsedTime = 0.0f;
    // �}�e���A�����Q��
    Material material;
    // �ύX����F
    Color color;

    // �A���t�@�l�ς���t���O
    bool isDraw = false;

    void Start()
    {
        // �}�e���A�����擾
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDraw)
        {
            if (elapsedTime < fadeDuration)
            {
                // �^�C�}�[��i�߂�
                elapsedTime += Time.deltaTime;
                // �A���t�@�l���X�V
                color = material.color;
                color.a = Mathf.Clamp01(elapsedTime / fadeDuration); ;
                material.color = color;
            }
            // �G��`���I�������
            else
            {
                // �G��`�����[�h����߂�
                
            }
        }
    }

    public void Draw(bool isDraw_)
    {
        isDraw = isDraw_;
    }
}
