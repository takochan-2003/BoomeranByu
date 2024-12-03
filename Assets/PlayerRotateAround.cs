using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerRotateAround : MonoBehaviour
{
    [SerializeField, Tooltip("�^�[�Q�b�g�I�u�W�F�N�g")]
    private GameObject TargetObject;

    [SerializeField, Tooltip("��]��")]
    private Vector3 RotateAxis = Vector3.up;

    [SerializeField, Tooltip("���x�W��")]
    private float SpeedFactor = 0.1f;

    [SerializeField, Tooltip("���a����")]
    private float RadiusDistance = 10.0f;

    // Update is called once per frame
    void Update()
    {
        if (TargetObject == null) return;

        // �w��I�u�W�F�N�g�Ǝ��g�̌��݈ʒu���擾����
        Vector3 selfPosition = this.transform.position;
        Vector3 targetPosition = TargetObject.transform.position;

        // ���W���d�Ȃ��Ă����ꍇ�͉�]���̒�������ɗ��ꂽ�ꏊ�������ʒu�Ƃ���
        if (selfPosition.Equals(targetPosition))
        {
            // �����x�N�g�������߂邽�߁A��]���ɕ��s�łȂ��_�~�[�x�N�g�����쐬����
            Vector3 rotateAxisNormal = RotateAxis.normalized;
            Vector3 dummyDirectVector = Vector3.forward;
            if (Mathf.Abs(rotateAxisNormal.y) < 0.5f) dummyDirectVector = Vector3.up;

            // ��]���ƃ_�~�[�x�N�g�����璼���x�N�g�����Z�o���A�����ʒu��ݒ肷��
            Vector3 directVector = Vector3.Cross(RotateAxis, dummyDirectVector).normalized;
            selfPosition = directVector * RadiusDistance;
        }

        // �������̈ړ��ʂ͒Ǐ]����
        Vector3 diffVector = selfPosition - targetPosition;
        float diffMagnitude = diffVector.magnitude;
        float dot = Vector3.Dot(diffVector, RotateAxis);
        // ��]���Ƃ̓��ς����]�������ւ̈ړ��ʂ����߂�
        selfPosition -= RotateAxis.normalized * (diffMagnitude * dot);

        // ���݂̋����Ɣ��a�����̍������擾����
        float diffDistance = Vector3.Distance(selfPosition, targetPosition) - RadiusDistance;

        // �w�蔼�a�̋����ɂȂ�悤�߂Â�(or�����)
        this.transform.position = Vector3.MoveTowards(selfPosition, targetPosition, diffDistance);

        // �w��I�u�W�F�N�g�𒆐S�ɉ�]����
        this.transform.RotateAround(
            targetPosition,
            RotateAxis,
            360.0f / (1.0f / SpeedFactor) * Time.deltaTime
            );
    }
}
