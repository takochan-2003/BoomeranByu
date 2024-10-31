using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    //��������Ƃ��ɂ�����l
    private float stopPower;
    private float backPower;
    //��������Ƃ��ɂ�����l�̍ŏ��l
    private const�@float minStopPower = 0.003f;
    private const float minBackPower = 0.003f;
    //��̒l�̍ő�l
    private const float kPower = 0.12f;
    //�߂��Ă��邩���f����t���O
    private bool backFlag;
    //�^�C�}�[�ϐ�
    private int timer;
    //�G�ɒǔ����邩�̃t���O
    private bool homingFlag;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        Initialze();

        //Player���擾
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        //�v���C���[�ƌ��������킹��
        transform.rotation = playerScript.transform.rotation;
        //�v���C���[��throwPower���X�s�[�h�ɑ������
        speed = playerScript.throwPower;
        
        //�T�b��ɏ���
        Destroy(gameObject, 5);

        //SensorScript���擾
        sensor = GameObject.Find("sensor");
        sensorScript = sensor.GetComponent<SensorScript>();
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

            if(sensorScript.findTarget == false && homingFlag ==true)
            {
                // transform.rotation = Quaternion.LookRotation((sensorScript.targetPosition - transform.position), Vector3.up);
                transform.LookAt(sensorScript.targetPosition);
                homingFlag = false;
            }
        }
        else
        {
            //�u�[���������߂��Ă���Ƃ��ɋO�����v���C���[�Ɍ�����
            LookAt(player);
        }
        Debug.Log(stopPower);
    }

    //�u�[���������߂��Ă���Ƃ��ɋO�����v���C���[�Ɍ�����֐�
    public void LookAt(GameObject target)
    {
        timer++;
        if(timer % 30 == 0)
        {
            //�v���C���[�Ɍ�����
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
            stopPower = minStopPower;
        }
        if(backPower >= kPower)
        {
            backPower = minBackPower;
        }

    }

    void Initialze()
    {
        stopPower = minStopPower;
        backPower = minBackPower;
        backFlag = false;
        timer = 0;
        homingFlag = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[�ɐG�ꂽ�����A�e���������Ă���30F�ゾ�����������
        if (other.gameObject.tag == "Player"&& timer >= 30)
        {
            Destroy(gameObject);
            playerScript.throwFlag = true;
        }
    }

    //�G�ɓ���������|��
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
