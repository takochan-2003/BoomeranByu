using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject player;

    //Enemyのスピード
    private const float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーを取得
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //LookAt(player);
    }

    public void LookAt(GameObject target)
    {
        //プレイヤーに向ける
        transform.LookAt(target.transform);
        // プレイヤーに向かって移動
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    ////ブーメランに当たったら消滅させる
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shot")
        {
            Destroy(gameObject);
        }
    }
}
