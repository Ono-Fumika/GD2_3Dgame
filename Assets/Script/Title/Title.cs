using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    // ��]���邩�t���O
    bool isRotate = false;
    // ��]����ő厞��
    float rotateTime = 3.0f;
    // ���̎���
    float rotateTimer = 0;

    // �����p�x
    float initialYRotation;
    // �ڕW�p�x
    float targetYRotation = 2680f;

    TitleManeger titleManeger;

    void Start()
    {
        // �����p�x��ۑ�
        initialYRotation = transform.eulerAngles.y;
    }

    void Update()
    {
        // �t���O�������Ă�����
        if (isRotate)
        {
            // �^�C�}�[��i�߂�
            rotateTimer += Time.deltaTime;

            if (rotateTime > rotateTimer)
            {
                // ���Ԃ̐i�s�x���v�Z
                float t = Mathf.Clamp01(rotateTimer / rotateTime);
                // �C�[�W���O�֐����g�p���Đi�s�x��ϊ�
                float easeT = EaseFunctions.EaseInOutBack(t);
                // �V����Y����]�p�x���v�Z
                float newYRotation = Mathf.Lerp(initialYRotation, targetYRotation, easeT);
                // Y����]��K�p
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, newYRotation, transform.eulerAngles.z);
            }
            else
            {
                // �V�[���J�ڂ��J�n����
                Debug.Log("�Q�[���V�[���ɍs����");
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
