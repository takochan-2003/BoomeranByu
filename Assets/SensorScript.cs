using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    private GameObject[] targets;
    private GameObject closeEnemy;

    float closeDist;
    public bool findTarget;

    public Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        //初期値の設定
        closeDist = 1000;
        findTarget = true;
        targetPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (findTarget == true && (other.gameObject.tag == "Enemy"))
        {

            foreach (GameObject t in targets)
            {
                // コンソール画面での確認用コード
                print(Vector3.Distance(transform.position, t.transform.position));

                // このオブジェクト（センサー）と敵までの距離を計測
                float tDist = Vector3.Distance(transform.position, t.transform.position);

                // もしも「初期値」よりも「計測した敵までの距離」の方が近いならば、
                if (closeDist > tDist)
                {
                    // 「closeDist」を「tDist（その敵までの距離）」に置き換える。
                    // これを繰り返すことで、一番近い敵を見つけ出すことができる。
                    closeDist = tDist;

                    // 一番近い敵の情報をcloseEnemyという変数に格納する（★）
                    closeEnemy = t;
                }
            }

            targetPosition = closeEnemy.transform.position;
            findTarget = false;
            Debug.Log(targetPosition);
        }
       
        
    }
}
