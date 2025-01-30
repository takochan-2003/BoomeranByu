using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject player;

    GameObject gameManager;
    ScoreScript scoreScript;

    //Enemyのスピード
    private float speed = 1.0f;
    private float add;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーを取得
        player = GameObject.Find("Player");

        //ScoreScriptを取得
        gameManager = GameObject.Find("GameManager");
        scoreScript = gameManager.GetComponent<ScoreScript>();

        //敵を倒すたびに速度が上がる
        add = scoreScript.score / 1000;
        speed += add;

    }

    // Update is called once per frame
    void Update()
    {
        LookAt(player);
    }

    public void LookAt(GameObject target)
    {
        //プレイヤーに向ける
        transform.LookAt(target.transform);
        // プレイヤーに向かって移動
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
