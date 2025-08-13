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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 v = player.transform.position - this.transform.position;
        v = v.normalized * m_speed;

        // 速度ベクトルをセットする
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = v;
    }
    void OnCollisionEnter(Collision collision)
    {
        // タグが "KillWall" または 自身が "Enemy" タグの場合に自身を破壊
        if (collision.gameObject.CompareTag("KillWall"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            
        }

    }
}