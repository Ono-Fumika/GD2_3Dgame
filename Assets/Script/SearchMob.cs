using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchMob : MonoBehaviour
{
    // Mob
    GameObject target;
    // �͈͓���Mob�̃��X�g
    [SerializeField]
    List<GameObject> mobs = new List<GameObject>();
    // �v���C���[
    Player player;

    void Start()
    {
        player = transform.parent.GetComponent<Player>();
    }

    void Update()
    {
        // ���X�g�̒������ԃv���C���[�Ƌ������߂����̂�I��
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
       
        // Mob�ɓ���������
        if (other.tag == "Mob")
        {
            // ���X�g��Mob��ǉ�
            if (!mobs.Contains(other.gameObject))
            {
                mobs.Add(other.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    { 
        // Mob���͈͊O�ɏo����
        if (other.CompareTag("Mob"))
        {
            // ���X�g����O��
            if (mobs.Contains(other.gameObject))
            {
                mobs.Remove(other.gameObject);
            }
        }
    }
}
