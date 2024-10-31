using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    private GameObject[] targets;
    private GameObject closeEnemy;

    float closeDist;
    public bool findTarget;

    public Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        //�����l�̐ݒ�
        closeDist = 1000;
        findTarget = true;
        targetPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (findTarget == true && (other.gameObject.tag == "Enemy"))
        {

            foreach (GameObject t in targets)
            {
                // �R���\�[����ʂł̊m�F�p�R�[�h
                print(Vector3.Distance(transform.position, t.transform.position));

                // ���̃I�u�W�F�N�g�i�Z���T�[�j�ƓG�܂ł̋������v��
                float tDist = Vector3.Distance(transform.position, t.transform.position);

                // �������u�����l�v�����u�v�������G�܂ł̋����v�̕����߂��Ȃ�΁A
                if (closeDist > tDist)
                {
                    // �ucloseDist�v���utDist�i���̓G�܂ł̋����j�v�ɒu��������B
                    // ������J��Ԃ����ƂŁA��ԋ߂��G�������o�����Ƃ��ł���B
                    closeDist = tDist;

                    // ��ԋ߂��G�̏���closeEnemy�Ƃ����ϐ��Ɋi�[����i���j
                    closeEnemy = t;
                }
            }

            targetPosition = closeEnemy.transform.position;
            findTarget = false;
            Debug.Log(targetPosition);
        }
       
        
    }
}
