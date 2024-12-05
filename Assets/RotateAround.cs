using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform target; // オブジェクトAのTransform
    public float orbitSpeed = 50f; // 回転速度
    public float distance = 13f; // 回転半径

    void Update()
    {
        // オブジェクトAを中心にオブジェクトBを回転させる
        Orbit();

        // オブジェクトBが常にオブジェクトAを向くようにする
        LookAtTarget();
    }

    void Orbit()
    {
        // 時間に基づいてオブジェクトBの新しい位置を計算
        float angle = orbitSpeed * Time.deltaTime;
        transform.RotateAround(target.position, Vector3.up, angle);

        //// オブジェクトBをターゲットから一定の距離に維持
        Vector3 direction = transform.position - target.position;
        direction.Normalize();
        transform.position = target.position + direction * distance;
    }

    void LookAtTarget()
    {
        transform.LookAt(target);
    }
}
