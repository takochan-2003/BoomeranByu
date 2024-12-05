using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //�X�R�A��\������
    [SerializeField] TextMeshProUGUI scoreText;

    //�X�R�A
    private int score;

    //���Z�O�̃X�R�A
    private int previousValue;

    //�J�E���g�A�b�v����
    private bool isCountup = true;

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
            //�X�R�A�\�����X�V����
            scoreText.SetText("{0:000000}", previousValue);
        }
        //Debug.Log(previousValue);
    }

    public void AddPoint(int point)
    {
        //���_�����Z�����O�̒l
        previousValue = score;
        //�X�R�A���X�V
        score += point;
        //�A�j���[�V�������Đ����ł���΃X�L�b�v
        if(isCountup == true)
        {
            sequence.Kill(true);
        }
        //�J�E���g�A�b�v�A�j���[�V�����̎��s
        CountUpAnim();
    }

    void CountUpAnim()
    {
        //�A�j���[�V�����J�n
        isCountup = true;
        sequence = DOTween.Sequence()
            .Append(DOTween.To(
            () => previousValue,
            num => previousValue = num,
            score,
            0.5f))
        //�����ҋ@���Ă���
        .AppendInterval(0.1f)
        //�X�R�A�\���̍X�V���~
        .AppendCallback(() => isCountup = false);
    }

    public void Add(int point)
    {
        previousValue += point;
    }


}
