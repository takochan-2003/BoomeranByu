using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField, Tooltip("�\�����W")]
    private Vector3 pos = Vector3.zero;

    //�X�R�A
    private int score;

    //���Z�O�̃X�R�A
    private int previousValue;

    //�J�E���g�A�b�v����
    private bool isCountup;

    //�J�E���g�A�b�v�A�j���[�V����
    Sequence sequence;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�J�E���g�A�b�v�̃A�j���[�V�������ł����
        if(isCountup == true)
        {
            
        }
    }
}
