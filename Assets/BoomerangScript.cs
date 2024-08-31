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
        //Player�����炤
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        //�v���C���[�ƌ��������킹��
        transform.rotation = playerScript.transform.rotation;
        //�v���C���[��throwPower���X�s�[�h�ɑ������
        speed = playerScript.throwPower;
        velocity = transform.rotation * new Vector3(0, 0, speed);
        //�T�b��ɏ���
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

}
