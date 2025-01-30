using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    //スコアを表示する
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //スコア表示を更新する
        scoreText.SetText("{0:000000}", Score.Score_);
    }
}
