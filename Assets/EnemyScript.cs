using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private GameObject[] targets;
    private GameObject closeEnemy;

    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        //�����l�̐ݒ�
        float closeDist = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
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