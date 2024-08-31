using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{

    GameObject player;
    PlayerScript playerScript;

    public Rigidbody rb;

    float speed;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
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
        velocity = transform.rotation * new Vector3(0, 0, speed);
        //ブーメランの移動
        transform.position += velocity * Time.deltaTime;
        //速度の減速
        speed -= 0.05f;
    }

}
