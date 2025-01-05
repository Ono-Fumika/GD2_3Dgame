using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MOB : MonoBehaviour
{
    // ナビメッシュ
    [SerializeField]
    NavMeshAgent navmeshAgent_;
    //巡回ポイントリスト
    [SerializeField]
    List<Transform> points_ = new();
    int destPoint_ = 0;

    [SerializeField]
    mobPlayer mobPlayer;


    void Start()
    {
        
    }

    void Update()
    {
        // 目指すポイントがあるなら動く
        if (!navmeshAgent_.pathPending && navmeshAgent_.remainingDistance < 0.5f)
        {
            Move();
        }
    }

    void Move()
    {
        // ポイントが設定されていないなら
        if (points_.Count == 0)
        {
            return;
        }

        // 次のポイントへ移動する
        navmeshAgent_.destination = points_[destPoint_].position;
        // 次のポイントを設定
        destPoint_ = (destPoint_ + 1) % points_.Count;
    }

    public void MobDestroy()
    {
        mobPlayer newMob = Instantiate(mobPlayer, transform.position, transform.rotation);
        newMob.Initialize(points_);
        Destroy(gameObject);
    }

}
