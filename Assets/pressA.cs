using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressA : MonoBehaviour
{
    // ã‰º‰^“®‚ÌU•
    float amplitude = 0.5f; 
    // ã‰º‰^“®‚Ì‘¬“x
    float speed = 1.0f; 
    // ‰ŠúˆÊ’u
    private Vector3 startPosition; void Start() { 
        // ‰ŠúˆÊ’u‚ğ•Û‘¶
        startPosition = transform.position; 
    }
    void Update()
    {
        // ã‰º‰^“®‚ğŒvZ
        float newY = startPosition.y + amplitude * Mathf.Sin(speed * Time.time); 
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
