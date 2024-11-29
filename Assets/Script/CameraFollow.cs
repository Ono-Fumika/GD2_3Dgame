using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // �v���C���[�̍��W
    public Transform player;
    // �J�����ƃv���C���[�̃I�t�Z�b�g
    Vector3 offset = new Vector3(0, 2.0f, -6.0f);

    void LateUpdate()
    {
        // �J�����̈ʒu���v���C���[�̈ʒu�ɐݒ�
        Vector3 desiredPosition = player.position + offset;
        transform.position = desiredPosition;
    }
}
