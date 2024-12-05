using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Police : MonoBehaviour
{
    // �i�r���b�V��
    [SerializeField]
    NavMeshAgent navmeshAgent;
    // �v���C���[
    [SerializeField]
    Player player;
    // �v���C���[��ǂ������Ă��邩�̃t���O
    bool isChasePlayer = false;
    // �v���C���[�����������̃t���O
    //bool isFindPlayer = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isChasePlayer)
        {
            // �v���C���[��ǂ�������
            ChasePlayer();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // �͈͂ɓ�������
        if (other.tag == "SearchRange")
        {
            isChasePlayer = true;
        }
    }

    void ChasePlayer()
    {
        // �v���C���[��ǂ�������
        navmeshAgent.destination = player.transform.position;

        //// �v���C���[�ƃL�������K��
        //Vector3 direction = (player.transform.position - transform.position).normalized;
        //// �v���C���[�Ɍ����ă��C���΂�
        //Ray ray = new(transform.position,direction);
        //// ���C���v���C���[�ɓ��������猩����
        //RaycastHit hit;
        //if(Physics.Raycast(ray,out hit))
        //{
        //    isFindPlayer = true;
        //}

    }

}
