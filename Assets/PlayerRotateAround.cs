using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerRotateAround : MonoBehaviour
{
    [SerializeField, Tooltip("ターゲットオブジェクト")]
    private GameObject TargetObject;

    [SerializeField, Tooltip("回転軸")]
    private Vector3 RotateAxis = Vector3.up;

    [SerializeField, Tooltip("速度係数")]
    private float SpeedFactor = 0.1f;

    [SerializeField, Tooltip("半径距離")]
    private float RadiusDistance = 10.0f;

    // Update is called once per frame
    void Update()
    {
        if (TargetObject == null) return;

        // 指定オブジェクトと自身の現在位置を取得する
        Vector3 selfPosition = this.transform.position;
        Vector3 targetPosition = TargetObject.transform.position;

        // 座標が重なっていた場合は回転軸の直交方向に離れた場所を初期位置とする
        if (selfPosition.Equals(targetPosition))
        {
            // 直交ベクトルを求めるため、回転軸に平行でないダミーベクトルを作成する
            Vector3 rotateAxisNormal = RotateAxis.normalized;
            Vector3 dummyDirectVector = Vector3.forward;
            if (Mathf.Abs(rotateAxisNormal.y) < 0.5f) dummyDirectVector = Vector3.up;

            // 回転軸とダミーベクトルから直交ベクトルを算出し、初期位置を設定する
            Vector3 directVector = Vector3.Cross(RotateAxis, dummyDirectVector).normalized;
            selfPosition = directVector * RadiusDistance;
        }

        // 軸方向の移動量は追従する
        Vector3 diffVector = selfPosition - targetPosition;
        float diffMagnitude = diffVector.magnitude;
        float dot = Vector3.Dot(diffVector, RotateAxis);
        // 回転軸との内積から回転軸方向への移動量を求める
        selfPosition -= RotateAxis.normalized * (diffMagnitude * dot);

        // 現在の距離と半径距離の差分を取得する
        float diffDistance = Vector3.Distance(selfPosition, targetPosition) - RadiusDistance;

        // 指定半径の距離になるよう近づく(or離れる)
        this.transform.position = Vector3.MoveTowards(selfPosition, targetPosition, diffDistance);

        // 指定オブジェクトを中心に回転する
        this.transform.RotateAround(
            targetPosition,
            RotateAxis,
            360.0f / (1.0f / SpeedFactor) * Time.deltaTime
            );
    }
}
