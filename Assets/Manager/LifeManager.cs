using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeMager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[3];



    //�v���C���[�̗̑�(�ő�l�͂R)
    private int lifePoint = 3;

    void Update()
    {
       
    }

    public void Damage()
    {
        lifeArray[lifePoint - 1].SetActive(false);
        lifePoint--;
    }
}
