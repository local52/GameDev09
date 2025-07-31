using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の弾を制御するコンポーネント
/// 出現時のプレイヤーの位置を検出して、その方向に等速直線運動する
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;

    void Start()
    {
        // 速度ベクトルを求める
        GameObject player = GameObject.FindGameObjectWithTag("PlayerHead");
        Vector2 v = player.transform.position - this.transform.position;
        v = v.normalized * m_speed;

        // 速度ベクトルをセットする
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = v;
    }
}