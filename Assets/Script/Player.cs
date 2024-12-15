using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ��
    Wall wall;
    // �T�[�`�͈�
    SearchRange searchRange;
    // Mob
    public MOB targetMob;
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
        if (wall != null && targetMob == null)
        {
            DrawPaint();
        }
        // ���u��ς���
        if (targetMob != null && wall == null)
        {
            Debug.Log("���u�ɕ`�����"); // �f�o�b�O���b�Z�[�W��ǉ�

            // �X�y�[�X����������
            if (Input.GetKey(KeyCode.Space) || (Input.GetButton("Fire1")))
            {
                MOB mob = targetMob;
                mob.ChangeAppearance();
            }
        }
    }
    void Move()
    {
        // �ړ��X�s�[�h
        float moveSpeed = 3.0f;

        // ���X�e�B�b�N�̓��͂��擾
        float horizonal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // �J�����̑O���ƉE��������Ɉړ��������v�Z
        Transform cameraTransform = Camera.main.transform; 
        Vector3 forward = cameraTransform.forward; 
        Vector3 right = cameraTransform.right; 
        // Y�������𖳎����ĕ��ʏ�ł̕����ɕϊ�
        forward.y = 0; 
        right.y = 0; 
        forward.Normalize(); 
        right.Normalize(); 
        // ���͂Ɋ�Â��Ĉړ�����������
        Vector3 moveDir = forward * vertical + right * horizonal;
        if (moveDir != Vector3.zero)
        {
            // �ړ��x�N�g���𐳋K��
            moveDir.Normalize();
            transform.position += moveDir * moveSpeed * Time.deltaTime;
            // �v���C���[�̕�����i�s�����Ɍ�����
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
        }

    }
    void DrawPaint()
    {
        if (wall != null)
        {
            // �X�y�[�X����������
            if (Input.GetKey(KeyCode.Space) || (Input.GetButton("Fire1")))
            {
                // �ړ�����߂�
                isMove = false;
                // �G��`���A�j���[�V����

                // �ǂ���G��`���֐����Ăяo��
                wall.DrawPaint(true, this);
                // �͈͂�傫������
                searchRange.Spread();
            }
            // ��������
            if (Input.GetKeyUp(KeyCode.Space) || (Input.GetButtonUp("Fire1")))
            {
                // �ǂ���G��`���֐����Ăяo��
                wall.DrawPaint(false, this);
                // DrawColision������
                wall.DrawColisionDestory();
                isMove = true;
                wall = null;
            }
        }
    }
    public void StopDraw()
    {
        // DrawColision������
        wall.DrawColisionDestory();
        isMove = true;
        wall = null;
    }
    public void SetTarget(MOB search_)
    {
        targetMob = search_;
    }
    void OnCollisionEnter(Collision collision)
    {
        // DrawColision�ɓ���������
        if (collision.transform.tag == "DrawColosion")
        {
            Debug.Log("�G��`�����"); // �f�o�b�O���b�Z�[�W��ǉ�

            // �ǂ𔻒肷��
            wall = collision.transform.parent.GetComponent<Wall>();
            searchRange = wall.GetComponentInChildren<SearchRange>();
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());

            // �^�[�Q�b�g��ǂɂ���
            targetMob = null;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        // DrawColosion���痣�ꂽ��
        if (collision.transform.CompareTag("DrawColosion"))
        {
            wall = null;
            // �Փ˂��ēx�L���ɂ���
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), false);
        }
    }
}
