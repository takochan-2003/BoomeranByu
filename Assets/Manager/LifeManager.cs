using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeMager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[3];
    public FadeOutScript fadeOutScript;

    //プレイヤーの体力(最大値は３)
    private int lifePoint = 3;

    void Update()
    {
        if(lifePoint <= 0)
        {
            fadeOutScript.CallCoroutine();
        }
    }

    public void Damage()
    {
        if(lifePoint >= 1)
        {
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
        }
    }
}
