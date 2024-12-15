using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // �v���C���[�̍��W
    public Transform player;
    // �J�����ƃv���C���[�̃I�t�Z�b�g
    Vector3 offset = new Vector3(0, 4.0f, -6.0f);
    // �J�����̉�]�X�s�[�h
    //float rotationSpeed = 100.0f;

    void Update()
    {
        //float horizontalInput = Input.GetAxis("RightStickHorizontal");

        //// �J�����̉�]
        //if (horizontalInput != 0)
        //{ // �J�����̃I�t�Z�b�g�𐅕��ɉ�]������
        //    Quaternion horizontalRotation = Quaternion.AngleAxis(horizontalInput * rotationSpeed * Time.deltaTime, Vector3.up);
        //    // �I�t�Z�b�g�𐅕���]�ōX�V
        //    offset = horizontalRotation * offset;
        //}
        //    Vector3 desiredPosition = player.position + offset;
        //transform.position = desiredPosition;
        // // �J�������v���C���[�̕����Ɍ�����
        // transform.LookAt(player);

        //Debug.Log("RightStickHorizontal Input: " + horizontalInput);

        // �J�����̈ʒu���v���C���[�̈ʒu�ɐݒ�
        Vector3 desiredPosition = player.position + player.TransformDirection(offset);
        transform.position = desiredPosition;
        // �J�����̉�]���v���C���[�̉�]�Ɉ�v������
        transform.rotation = Quaternion.Euler(9.5f, player.eulerAngles.y, 0);

    }
}
