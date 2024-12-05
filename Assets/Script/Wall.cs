using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // ŠG
    Paint paint;
    // DrawColision
    [SerializeField]
    GameObject drawObject;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DrawPaint(bool isDraw,Player player_)
    {
        paint = GetComponentInChildren<Paint>();
        if (paint != null)
        {
            paint.Draw(isDraw,player_);
        }
    }

    public void DrawColisionDestory()
    {
        Destroy(drawObject);
    }
}
