using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBulletController : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;
    [SerializeField] float m_time = 0f;
    [SerializeField] ScoreManeg _scoreManeg; // ★ スコア管理スクリプトを参照
    [SerializeField] AudioClip shootSound;   // 発射音

    void Start()
    {
        // 弾の進行方向を決定
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        Rigidbody rb = GetComponent<Rigidbody>();
        if(shootSound != null)
        {
            AudioSource.PlayClipAtPoint(shootSound, this.transform.position);
        }

        if (enemy != null)
        {
            Vector3 v = (enemy.transform.position - this.transform.position).normalized * m_speed;
            rb.velocity = v;
        }
        else
        {
            rb.velocity = Vector3.forward * m_speed;
        }

        // ScoreManeg をシーンから探す
        if (_scoreManeg == null)
        {
            _scoreManeg = FindObjectOfType<ScoreManeg>();
            //if (_scoreManeg == null)
            //{
            //    Debug.LogError("⚠ ScoreManeg がシーンに存在しません！");
            //}
            //else
            //{
            //    Debug.Log("✅ ScoreManeg を取得しました");
            //}
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // KillWall に当たったら消える
        if (collision.gameObject.CompareTag("KillWall"))
        {
            Destroy(gameObject);
        }

        // Enemy に当たったら処理
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            GameManager.Instance.KillCount += 1;
            if (_scoreManeg != null)
            {
                ScoreManeg.Score += 100; // ★ 1キル = 100点
            }
        }
    }

    void Update()
    {
        m_time += Time.deltaTime;
        if (m_time >= 2)
        {
            Destroy(gameObject);
        }
    }
}
