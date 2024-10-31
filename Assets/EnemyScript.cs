using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    private float speed = 2.0f;

    //Enemyのスピード
    private const float speed = 2.0f;
        player = GameObject.Find("Player");
    void Start()
    {
        //プレイヤーを取得
        player = GameObject.Find("Player");
    }
        LookAt(player);

    }

    public void LookAt(GameObject target)
    {
        //プレイヤーに向ける
        transform.LookAt(target.transform);
        // プレイヤーに向かって移動
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
