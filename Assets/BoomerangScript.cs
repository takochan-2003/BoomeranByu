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
        //velocity�쐬
        velocity = transform.rotation * new Vector3(0, 0, speed);
        //�u�[�������̈ړ�
        transform.position += velocity * Time.deltaTime;
        Debug.Log(speed);
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
            //�����~�܂�؂����班�����������Ė߂��Ă���
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
