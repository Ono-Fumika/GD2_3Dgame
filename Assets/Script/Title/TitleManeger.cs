using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManeger : MonoBehaviour
{
    [SerializeField]
    Title title;

    void Start()
    {
        
    }

    void Update()
    {
        // �X�y�[�X����������^�C�g������
        if (Input.GetKey(KeyCode.Space) || (Input.GetButton("Fire1")))
        {
            title.SetRotate(this);
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
