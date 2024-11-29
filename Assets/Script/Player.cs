using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ��
    public Wall wall;
    // �T�[�`�͈�
    SearchRange searchRange;
    // �ړ��ł��邩�̃t���O
    bool isMove = true;

    void Start()
    {
        
    }

    void Update()
    {
        // �ړ�
        if (isMove)
        {
            Move();
        }
        // �G��`��
        if(wall != null)
        {
            DrawPaint();
        }
        
    }

    void Move()
    {
        // �ړ��X�s�[�h
        float moveSpeed = 3.0f;
        // ��]�X�s�[�h
        float rotateSpeed = 5.0f;
        // ��ˉ�
        Vector3 moveDir = Vector3.zero;
        
        // �ړ�����
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveDir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveDir += Vector3.right;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveDir += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveDir += Vector3.back;
        }
        if(moveDir != Vector3.zero)
        {
            // �ړ��x�N�g���𐳋K��
            moveDir.Normalize();
            transform.position += moveDir * moveSpeed * Time.deltaTime;
            // �v���C���[�̕�����i�s�����Ɍ�����
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
        }
        

    }
    void DrawPaint()
    {
        if (wall != null)
        {
            // �X�y�[�X����������
            if (Input.GetKey(KeyCode.Space))
            {
                // �ړ�����߂�
                isMove = false;
                // �G��`���A�j���[�V����

                // �ǂ���G��`���֐����Ăяo��
                wall.DrawPaint(true);
                // �͈͂�傫������
                searchRange.Spread();
            }
            // ��������
            if (Input.GetKeyUp(KeyCode.Space))
            {
                // �ǂ���G��`���֐����Ăяo��
                wall.DrawPaint(false);
                // DrawColision������
                wall.DrawColisionDestory();
                isMove = true;
                wall = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // DrawColision�ɓ���������
        if (other.tag == "DrawColosion")
        {
            // �ǂ𔻒肷��
            wall = other.transform.parent.GetComponent<Wall>();
            searchRange = wall.GetComponentInChildren<SearchRange>();

            if(searchRange == null)
            {
                Debug.Log("�Ȃ��I");
            }
        }
    }

}
