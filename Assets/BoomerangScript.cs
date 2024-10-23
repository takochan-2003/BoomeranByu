using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{

    GameObject player;
    PlayerScript playerScript;

    public Rigidbody rb;

    float speed;

    //��������Ƃ��ɂ�����l
    float stopPower;
    float backPower;
    //��̒l�̍ő�l
    float kPower;

    //�߂��Ă��邩���f����t���O
    bool backFlag;
    //�^�C�}�[�ϐ�
    int timer;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        Initialze();

        //Player�����炤
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        //�v���C���[�ƌ��������킹��
        transform.rotation = playerScript.transform.rotation;
        //�v���C���[��throwPower���X�s�[�h�ɑ������
        speed = playerScript.throwPower;
        
        //�T�b��ɏ���
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //���x�����X�ɉ�����
        Easing();
        if(backFlag == false)
        {
            //velocity�쐬
            velocity = transform.rotation * new Vector3(0, 0, speed);
            //�u�[�������̈ړ�
            transform.position += velocity * Time.deltaTime;
        }
        else
        {
            LookAt(player);
        }
        Debug.Log(speed);
    }

    public void LookAt(GameObject target)
    {
        timer++;
        if(timer % 30 == 0)
        {
            transform.LookAt(target.transform);
        }
        GetComponent<Rigidbody>().velocity = transform.forward.normalized * (speed) * -1;
    }

    void Easing()
    {
        if(speed >= 0.0f)
        {
            //�����i��ł���Ƃ��ɏ������������Ă���
            stopPower += 0.0005f;
            speed = speed - stopPower;
        }
        else
        {
            backFlag = true;
            //�����~�܂�؂����班�����������Ė߂��Ă���
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
        //�v���C���[�ɐG�ꂽ�����A�e���������Ă���30F�ゾ�����������
        if (other.gameObject.tag == "Player"&& timer >= 30)
        {
            Destroy(gameObject);
        }
    }
}
