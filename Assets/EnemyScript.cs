using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    private float speed = 2.0f;

    //Enemy�̃X�s�[�h
    private const float speed = 2.0f;
        player = GameObject.Find("Player");
    void Start()
    {
        //�v���C���[���擾
        player = GameObject.Find("Player");
    }
        LookAt(player);

    }

    public void LookAt(GameObject target)
    {
        //�v���C���[�Ɍ�����
        transform.LookAt(target.transform);
        // �v���C���[�Ɍ������Ĉړ�
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //�v���C���[�Ɍ�����
        transform.LookAt(target.transform);
        // �v���C���[�Ɍ������Ĉړ�
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    ////�u�[�������ɓ�����������ł�����
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shot")
        {
            Destroy(gameObject);
        }
    }
}
