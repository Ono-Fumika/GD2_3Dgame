using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
    [SerializeField]
    List<GameObject> paintWallList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> endList = new List<GameObject>();
    [SerializeField]
    bool isClear = false;

    [SerializeField]
    TextMeshProUGUI progressText;

    int maxPaintWallCount;
    int endCount = 0;

    void Start()
    {
        GameObject[] paintWalls = GameObject.FindGameObjectsWithTag("Wall");
        // リストに追加
        foreach(GameObject paintWall in paintWalls)
        {
            paintWallList.Add(paintWall);
        }
        // 最初のpaintWallオブジェクトリストの個数を最大値として設定
        maxPaintWallCount = paintWallList.Count; 
        // 初期の進行状況を表示
        UpdateProgressText();
    }

    void Update()
    {
        // endフラグが立っているオブジェクトをチェックしてendListに移動
        for (int i = paintWallList.Count - 1; i >= 0; i--) { 
            Wall paintWall = paintWallList[i].GetComponent<Wall>(); 
            if (paintWall != null && paintWall.end) { 
                endList.Add(paintWallList[i]);
                paintWallList.RemoveAt(i);
                endCount++; // endListに入った数をカウント
                UpdateProgressText(); // 進行状況を更新
            } 
        } 
        // すべてのオブジェクトがendListに移動されたかチェック
        if (paintWallList.Count == 0 && !isClear) { 
            isClear = true;
            SceneManager.LoadScene("ClearScene");
        }
    }
    void UpdateProgressText()
    { 
        // 進行状況を「4/5」の形式で更新
      progressText.text = endCount + "/" + maxPaintWallCount;
    }
}


