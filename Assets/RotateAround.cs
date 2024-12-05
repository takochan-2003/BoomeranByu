using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform target; // �I�u�W�F�N�gA��Transform
    public float orbitSpeed = 50f; // ��]���x
    public float distance = 13f; // ��]���a

    void Update()
    {
        // �I�u�W�F�N�gA�𒆐S�ɃI�u�W�F�N�gB����]������
        Orbit();

        // �I�u�W�F�N�gB����ɃI�u�W�F�N�gA�������悤�ɂ���
        LookAtTarget();
    }

    void Orbit()
    {
        // ���ԂɊ�Â��ăI�u�W�F�N�gB�̐V�����ʒu���v�Z
        float angle = orbitSpeed * Time.deltaTime;
        transform.RotateAround(target.position, Vector3.up, angle);

        //// �I�u�W�F�N�gB���^�[�Q�b�g������̋����Ɉێ�
        Vector3 direction = transform.position - target.position;
        direction.Normalize();
        transform.position = target.position + direction * distance;
    }

    void LookAtTarget()
    {
        transform.LookAt(target);
    }
}
