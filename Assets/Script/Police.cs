using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Police : MonoBehaviour
{
    // ナビメッシュ
    [SerializeField]
    NavMeshAgent navmeshAgent;
    // プレイヤー
    [SerializeField]
    Player player;
    // プレイヤーを追いかけているかのフラグ
    bool isChasePlayer = false;
    // プレイヤーを見つけたかのフラグ
    //bool isFindPlayer = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isChasePlayer)
        {
            // プレイヤーを追いかける
            ChasePlayer();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // 範囲に入ったら
        if (other.tag == "SearchRange")
        {
            isChasePlayer = true;
        }
    }

    void ChasePlayer()
    {
        // プレイヤーを追いかける
        navmeshAgent.destination = player.transform.position;

        //// プレイヤーとキョリ正規化
        //Vector3 direction = (player.transform.position - transform.position).normalized;
        //// プレイヤーに向けてレイを飛ばす
        //Ray ray = new(transform.position,direction);
        //// レイがプレイヤーに当たったら見つける
        //RaycastHit hit;
        //if(Physics.Raycast(ray,out hit))
        //{
        //    isFindPlayer = true;
        //}

    }

}
