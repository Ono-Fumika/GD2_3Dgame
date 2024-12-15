using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchMob : MonoBehaviour
{
    // Mob
    public MOB target;
    // 範囲内のMobのリスト
    [SerializeField]
    List<MOB> mobs = new List<MOB>();
    // プレイヤー
    Player player;

    void Start()
    {
        player = transform.parent.GetComponent<Player>();
    }

    void Update()
    {
        // リストの中から一番プレイヤーと距離が近いものを選ぶ
        if (mobs.Count > 0)
        {
            float closestDistance = Mathf.Infinity;
            MOB closestMob = null;

            foreach (MOB mob in mobs)
            {
                float distance = Vector3.Distance(player.transform.position, mob.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestMob = mob;
                }
            }

            target = closestMob;
            player.SetTarget(target);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        // Mobに当たったら
        if (other.tag == "Mob")
        {
            MOB mob = other.GetComponent<MOB>(); 
            if (mob != null && !mobs.Contains(mob))
            {
                mobs.Add(mob);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    { 
        // Mobが範囲外に出たら
        if (other.CompareTag("Mob"))
        {
            MOB mob = other.GetComponent<MOB>();
            if(mob != null && mobs.Contains(mob))
            {
                mobs.Remove(mob);
                // ターゲットだった場合ターゲットからも外す
                if (mob == target)
                {
                    target = null;
                }
            }
            
        }
    }
}
