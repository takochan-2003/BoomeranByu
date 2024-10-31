using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{

    GameObject player;
    PlayerScript playerScript;
    GameObject sensor;
    SensorScript sensorScript;

    public Rigidbody rb;

    float speed;

    //減速するときにかかる値
    private float stopPower;
    private float backPower;
    //上の値の最大値
    private float kPower;

    //戻っているか判断するフラグ
    private bool backFlag;
    //タイマー変数
    private int timer;
    //敵に追尾するかのフラグ
    public bool homingFlag;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        Initialze();

        //Playerを取得
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        //プレイヤーと向きを合わせる
        transform.rotation = playerScript.transform.rotation;
        //プレイヤーのthrowPowerをスピードに代入する
        speed = playerScript.throwPower;
        
        //５秒後に消滅
        //Destroy(gameObject, 5);

        //SensorScriptを取得
        sensor = GameObject.Find("sensor");
        sensorScript = sensor.GetComponent<SensorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //速度を徐々に下げる
        Easing();
        if(backFlag == false)
        {
            //velocity作成
            velocity = transform.rotation * new Vector3(0, 0, speed);
            //ブーメランの移動
            transform.position += velocity * Time.deltaTime;

            if(sensorScript.findTarget == false)
            {
                transform.rotation = Quaternion.LookRotation((sensorScript.targetPosition - transform.position), Vector3.zero);
            }
        }
        else
        {
            //ブーメランが戻ってくるときに軌道をプレイヤーに向ける
            LookAt(player);
        }
        //Debug.Log(transform.position);
    }

    //ブーメランが戻ってくるときに軌道をプレイヤーに向ける関数
    public void LookAt(GameObject target)
    {
        timer++;
        if(timer % 30 == 0)
        {
            //プレイヤーに向ける
            transform.LookAt(target.transform);
        }
        GetComponent<Rigidbody>().velocity = transform.forward.normalized * (speed) * -1;
    }

    void Easing()
    {
        if(speed >= 0.0f)
        {
            //球が進んでいるときに少しずつ減速していく
            stopPower += 0.0005f;
            speed = speed - stopPower;
        }
        else
        {
            backFlag = true;
            //球が止まり切ったら少しずつ加速して戻っていく
            backPower += 0.0005f;
            speed = speed - backPower;
        }
       
        if(stopPower >= kPower)
        {
            stopPower = kPower;
        }
        if(backPower >= kPower)
        {
            backPower = kPower;
        }

    }

    void Initialze()
    {
        stopPower = 0.001f;
        backPower = 0.001f;
        kPower = 0.06f;
        backFlag = false;
        timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーに触れた時かつ、弾が発生してから30F後だったら消える
        if (other.gameObject.tag == "Player"&& timer >= 30)
        {
            Destroy(gameObject);
            playerScript.throwFlag = true;
        }
    }

    //敵に当たったら倒す
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
