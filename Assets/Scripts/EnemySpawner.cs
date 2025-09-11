using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("召喚するプレハブ")]
    [SerializeField] public GameObject prefab;

    [Header("召喚間隔（秒）")]
    [SerializeReference] public float spawnInterval = 2f;

    [Header("召喚位置")]
    [SerializeField] public Transform spawnPoint;

    [Header("レベル１の時")]
    [SerializeField] public float _1_Interval = 10;


    [Header("レベル２の時")]
    [SerializeField] public float _2_Interval = 5;


    [Header("レベル３の時")]
    [SerializeField] public float _3_Interval = 5;


    [Header("バージョン管理０，１，２")]
    [SerializeField] public int _versions = 0;

    private float timer;
    private float _timer;
    public float _Kill; // 弾の出現時間を管理するための変数

    void Update()
    {
        _timer += Time.deltaTime;
        timer += Time.deltaTime;

        _Kill = GameManager.Instance.KillCount; // 全体のキル数を取得
        // レベル切り替え
        if (_Kill >= 30)
        {
            _versions += 1;
            GameManager.Instance.KillCount = 0; // キル数をリセット
        }




        // バージョンごとの間隔設定
        if (_versions == 0)
        {
            spawnInterval = _1_Interval; 
        }
        else if (_versions == 1)
        {
            spawnInterval = _2_Interval; 
        }
        else if (_versions == 2)
        {
            spawnInterval = _3_Interval; 
        }
        else
        {
            spawnInterval = 5; // レベル0は召喚間隔無限
        }

        // 召喚処理
        if (timer >= spawnInterval)
        {
            if (_versions >= 0) // レベル0以外
            {
                Spawn();
            }
            timer = 0f;
        }
    }

    void Spawn()
    {
        {
            // spawnPoint が指定されていなければこのオブジェクトの位置を使用
            Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
