using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpowner : MonoBehaviour
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
    private int _interval;
    private float _interval1;
    private float _interval2;
    private float _interval3;
    void Update()
    {
        _timer += Time.deltaTime;
        spawnInterval = _interval;

        if (_timer >= _interval1 && _versions == 0)
        {
            _1_Interval = 10f; // レベル1の召喚間隔
        }

        if (_timer >= _interval2 && _versions == 1)
        {
            _2_Interval = 5f; // レベル2の召喚間隔
        }

        if (_timer >= _interval3 && _versions == 2)
        {
            _3_Interval = 2f; // レベル3の召喚間隔
        }
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Spawn();
            timer = 0f;
        }
    }
    

    void Spawn()
    {
        // spawnPoint が指定されていなければこのオブジェクトの位置を使用
        Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;
        Instantiate(prefab, position, Quaternion.identity);
    }
}
