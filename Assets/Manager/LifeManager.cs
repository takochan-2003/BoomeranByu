using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeMager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[3];



    //プレイヤーの体力(最大値は３)
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
