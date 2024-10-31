using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private GameObject[] targets;
    private GameObject closeEnemy;

    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        //初期値の設定
        float closeDist = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
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
