using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;
    [SerializeField] float m_time = 0f;
    float m_goTime = 0f; // 弾の出現時間を管理するための変数
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        m_goTime += Time.deltaTime;
        if (m_goTime >= m_time)
        {
            if (GameObject.FindGameObjectWithTag("PlayerHead") == null)
            {
                return; // プレイヤーがいない場合は何もしない
            }
            // 速度ベクトルを求める
            GameObject player = GameObject.FindGameObjectWithTag("PlayerHead");
            Vector3 v = player.transform.position - this.transform.position;
            v = v.normalized * m_speed;

            // 速度ベクトルをセットする
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = v;
            m_goTime = 0f; // タイマーをリセット
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // タグが "Bullet" タグの場合に自身を破壊
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject); // 自身を破壊

        }
    }
}