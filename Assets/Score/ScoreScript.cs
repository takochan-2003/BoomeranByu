using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //スコアを表示する
    [SerializeField] TextMeshProUGUI scoreText;

    //スコア
    private int score;

    //加算前のスコア
    private int previousValue;

    //カウントアップ中か
    private bool isCountup = true;

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
            //スコア表示を更新する
            scoreText.SetText("{0:000000}", previousValue);
        }
        //Debug.Log(previousValue);
    }

    public void AddPoint(int point)
    {
        //得点が加算される前の値
        previousValue = score;
        //スコアを更新
        score += point;
        //アニメーションが再生中であればスキップ
        if(isCountup == true)
        {
            sequence.Kill(true);
        }
        //カウントアップアニメーションの実行
        CountUpAnim();
    }

    void CountUpAnim()
    {
        //アニメーション開始
        isCountup = true;
        sequence = DOTween.Sequence()
            .Append(DOTween.To(
            () => previousValue,
            num => previousValue = num,
            score,
            0.5f))
        //少し待機してから
        .AppendInterval(0.1f)
        //スコア表示の更新を停止
        .AppendCallback(() => isCountup = false);
    }

    public void Add(int point)
    {
        previousValue += point;
    }


}
