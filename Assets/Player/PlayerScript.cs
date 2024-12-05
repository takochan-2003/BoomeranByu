using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject enemy;
    public GameObject gameManager;
    public LifeMager lifeMagerScript;
    public CharacterController characterController;

   

    //移動の最高速度
    private float maxSpeed = 5.0f;
    //最低速度
    private float minSpeed = 2.0f;
    //旋回速度
    private float turnRate = 7.0f;
    //ベクトル
    private Vector3 velocity;

    //投げるパワーの値
    public float throwPower = 0.0f;
    //投げるパワーの最低値
    private const float kThrowPower = 13.0f;
    //投げるパワーの最大値
    private const float maxThrowPower = 30.0f;
    //ブーメランを投げるフラグ
    public bool throwFlag = true;

    //無敵時間のフラグ
    private bool invincibleFlag = false;
    //無敵時間の現在フレーム
    private float invincibleFlame = 0.0f;
    //無敵時間の最大フレーム
    private const float maxInvincibleFlame = 1.5f;

    //RenderTggleのスクリプトを取得
    private RenderTggle renderTggle;

    // Start is called before the first frame update
    void Start()
    {
        //rendertggleを取得
        renderTggle = GetComponent<RenderTggle>();

        //GameManagerを取得
        gameManager = GameObject.Find("GameManager");
        lifeMagerScript = gameManager.GetComponent<LifeMager>();

        //コントローラー取得
        this.characterController = this.GetComponent<CharacterController>();
        //速度を0にする
        this.velocity = Vector3.zero;


    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Throw();

        TouchEnemy();
    }

    private void Move()
    {
        Vector3 vec = this.velocity;
        //移動速度
        float speed = 0.0f;


        ////キャラクターが地面に接しているかを判定
        //if (this.characterController.isGrounded)
        //{
        //    //パッドのスティック入力を所得して移動ベクトルを作成
        //    vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //    //入力値が0.1以上なら速さを設定
        //    if (vec.magnitude > 0.1)
        //    {
        //        //スティックの倒し具合で速さを変更
        //        speed = Mathf.Lerp(this.minSpeed, this.maxSpeed, vec.magnitude);

        //        //向きの変更
        //        Vector3 dir = vec.normalized;
        //        float rotate = Mathf.Acos(dir.z);
        //        if (dir.x < 0) rotate = -rotate;
        //        rotate *= Mathf.Rad2Deg;
        //        Quaternion Q = Quaternion.Euler(0, rotate, 0);

        //        //モデルの向きを変更
        //        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Q, this.turnRate);

        //    }
        //    //移動ベクトルを正規化
        //    vec = vec.normalized;
        //}

        //パッドのスティック入力を所得して移動ベクトルを作成
        vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //入力値が0.1以上なら速さを設定
        if (vec.magnitude > 0.1)
        {
            //スティックの倒し具合で速さを変更
            speed = Mathf.Lerp(this.minSpeed, this.maxSpeed, vec.magnitude);

            //向きの変更
            Vector3 dir = vec.normalized;
            float rotate = Mathf.Acos(dir.z);
            if (dir.x < 0) rotate = -rotate;
            rotate *= Mathf.Rad2Deg;
            Quaternion Q = Quaternion.Euler(0, rotate, 0);

            //モデルの向きを変更
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Q, this.turnRate);

        }
        //移動ベクトルを正規化
        vec = vec.normalized;

        //移動速度を設定
        this.velocity.x = vec.x * speed;
        this.velocity.y = vec.y;
        this.velocity.z = vec.z * speed;

        //重力による落下を設定
        //this.velocity.y += Physics.gravity.y * Time.deltaTime;


        if (!Input.GetButton("Fire3"))
        {
            //移動させる
            this.characterController.Move(this.velocity * Time.deltaTime);
        }
     
    }

    private void Throw()
    {
        if (throwFlag == true)
        {
            //球発射
            if (Input.GetButton("Fire3"))
            {

                //ボタンを押し続けている処理
                throwPower += 0.03f;
                if (throwPower >= maxThrowPower)
                {
                    throwPower = maxThrowPower;
                }


            }
            else if (Input.GetButtonUp("Fire3"))
            {

                ////ボタンを離した処理

                Vector3 position = transform.position;
                Instantiate(bullet, position, Quaternion.identity);

                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.AddForce(transform.forward * 100);

                throwFlag = false;
            }
            else
            {
                throwPower = kThrowPower;
            }
        }

        //Debug.Log(throwFlag);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 敵に衝突したら敵を消滅させて無敵時間を発生させる
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);

            //無敵時間の時はダメージを受けない
            if(invincibleFlag == false)
            {
                lifeMagerScript.Damage();
            }
            invincibleFlag = true;
        }
    }

    //敵と衝突した時の処理（ダメージとか無敵時間の管理）
    private void TouchEnemy()
    {
        //無敵時間の処理
        if (invincibleFlag == true)
        {
            renderTggle.OnFlag();
            invincibleFlame += Time.deltaTime;
            if(invincibleFlame >= maxInvincibleFlame)
            {
                invincibleFlag = false;
                invincibleFlame = 0.0f;
            }
        }
        else
        {
            renderTggle.OffFlag();
        }
    }

}
