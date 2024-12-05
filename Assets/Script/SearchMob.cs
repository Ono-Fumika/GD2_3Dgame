using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchMob : MonoBehaviour
{
    // Mob
    GameObject target;
    // 範囲内のMobのリスト
    [SerializeField]
    List<GameObject> mobs = new List<GameObject>();
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
            GameObject closestMob = null;

            foreach (GameObject mob in mobs)
            {
                float distance = Vector3.Distance(player.transform.position, mob.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestMob = mob;
                }
            }

            target = closestMob;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        // Mobに当たったら
        if (other.tag == "Mob")
        {
            // リストにMobを追加
            if (!mobs.Contains(other.gameObject))
            {
                mobs.Add(other.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    { 
        // Mobが範囲外に出たら
        if (other.CompareTag("Mob"))
        {
            // リストから外す
            if (mobs.Contains(other.gameObject))
            {
                mobs.Remove(other.gameObject);
            }
        }
    }
}
