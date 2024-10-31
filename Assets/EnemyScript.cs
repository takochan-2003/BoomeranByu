using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    private float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ////LookAt(player);
    }

    public void LookAt(GameObject target)
    {
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
