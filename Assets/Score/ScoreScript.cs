using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField, Tooltip("表示座標")]
    private Vector3 pos = Vector3.zero;

    //スコア
    private int score;

    //加算前のスコア
    private int previousValue;

    //カウントアップ中か
    private bool isCountup;

    //カウントアップアニメーション
    Sequence sequence;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //カウントアップのアニメーション中であれば
        if(isCountup == true)
        {
            
        }
    }
}
