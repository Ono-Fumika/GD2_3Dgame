using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchMob : MonoBehaviour
{
    // Mob
    public MOB target;
    // �͈͓���Mob�̃��X�g
    [SerializeField]
    List<MOB> mobs = new List<MOB>();
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
       
        // Mob�ɓ���������
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
        // Mob���͈͊O�ɏo����
        if (other.CompareTag("Mob"))
        {
            MOB mob = other.GetComponent<MOB>();
            if(mob != null && mobs.Contains(mob))
            {
                mobs.Remove(mob);
                // �^�[�Q�b�g�������ꍇ�^�[�Q�b�g������O��
                if (mob == target)
                {
                    target = null;
                }
            }
            
        }
    }
}
