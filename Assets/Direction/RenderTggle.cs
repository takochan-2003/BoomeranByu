using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RenderTggle : MonoBehaviour
{

    // 点滅させる対象
    [SerializeField] private Renderer _target;
    // 点滅周期[s]
    [SerializeField] private float _cycle = 0.05f;

    //点滅状態のフラグ
    [SerializeField]public bool renderFlag = false;

    private double _time;

    // Update is called once per frame
    void Update()
    {
        if (renderFlag == true)
        {
            // 内部時刻を経過させる
            _time += Time.deltaTime;
            
            // 周期cycleで繰り返す値の取得
            // 0～cycleの範囲の値が得られる
            var repeatValue = Mathf.Repeat((float)_time, _cycle);
            
            // 内部時刻timeにおける明滅状態を反映
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
