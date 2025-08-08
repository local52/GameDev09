using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の弾を制御するコンポーネント
/// 出現時のプレイヤーの位置を検出して、その方向に等速直線運動する
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerBulletController : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;

    void Start()
    {
        // 速度ベクトルを求める
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null)
        {
            Vector3 v = enemy.transform.position - this.transform.position;
            v = v.normalized * m_speed;
            Rigidbody rb1 = GetComponent<Rigidbody>();
            rb1.velocity = v;
        }
        if (enemy == null)
        {
            Vector3 vector3 = Vector3.forward;
            vector3 = vector3.normalized * m_speed;
            Rigidbody rb2 = GetComponent<Rigidbody>();
            rb2.velocity = vector3;
        }

        // 速度ベクトルをセットする

    }
}