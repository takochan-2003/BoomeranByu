using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //�G�v���n�u
    public GameObject enemyPrefab;
    //�G�������ԊԊu
    private float interval;
    //�o�ߎ���
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //���ԊԊu�����肷��
        interval = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԍv��
        time += Time.deltaTime;

        //�o�ߎ��Ԃ��������ԂɂȂ����Ƃ�(�������Ԃ��傫���Ȃ����Ƃ�)
        if (time > interval)
        {
            //enemy���C���X�^���X������(��������)
            GameObject enemy = Instantiate(enemyPrefab);
            //���������G�̍��W�����肷��
            //enemy.transform.position = this.transform.position;
            var position = transform.position;
            position.x = transform.position.x;
            position.y = 0;
            position.z = transform.position.z;
            enemy.transform.position = position;

           //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
           time = 0f;
        }
    }
}
