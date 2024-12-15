using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOB : MonoBehaviour
{
    [SerializeField]
    mobPlayer mobPlayer;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeAppearance(GameObject player_)
    {
        Instantiate(mobPlayer, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



}
