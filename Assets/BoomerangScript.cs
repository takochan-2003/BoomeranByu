using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{

    GameObject player;
    PlayerScript playerScript;

    public Rigidbody rb;

    float speed;
    float stopPower;
    float backPower;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        Initialze();

        //Playerをもらう
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        //プレイヤーと向きを合わせる
        transform.rotation = playerScript.transform.rotation;
        //プレイヤーのthrowPowerをスピードに代入する
        speed = playerScript.throwPower;
        
        //５秒後に消滅
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //速度を徐々に下げる
        Easing();
        //velocity作成
        velocity = transform.rotation * new Vector3(0, 0, speed);
        //ブーメランの移動
        transform.position += velocity * Time.deltaTime;
        Debug.Log(speed);
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
            //球が止まり切ったら少しずつ加速して戻っていく
            backPower += 0.0005f;
            speed = speed - backPower;
        }
       

    }

    void Initialze()
    {
        stopPower = 0.001f;
        backPower = 0.001f;
    }

 

}
