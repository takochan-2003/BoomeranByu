using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RenderTggle : MonoBehaviour
{

    // �_�ł�����Ώ�
    [SerializeField] private Renderer _target;
    // �_�Ŏ���[s]
    [SerializeField] private float _cycle = 0.05f;

    //�_�ŏ�Ԃ̃t���O
    [SerializeField]public bool renderFlag = false;

    private double _time;

    // Update is called once per frame
    void Update()
    {
        if (renderFlag == true)
        {
            // �����������o�߂�����
            _time += Time.deltaTime;
            
            // ����cycle�ŌJ��Ԃ��l�̎擾
            // 0�`cycle�͈̔͂̒l��������
            var repeatValue = Mathf.Repeat((float)_time, _cycle);
            
            // ��������time�ɂ����閾�ŏ�Ԃ𔽉f
            _target.enabled = repeatValue >= _cycle * 0.5f;

        }
        else
        {
            _target.enabled = true;
        }
        
    }

    public void OnFlag()
    {
        renderFlag = true;
    }

    public void OffFlag()
    {
        renderFlag = false;
    }
}
