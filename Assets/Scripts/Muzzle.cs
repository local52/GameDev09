using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{


    [Header("召喚するプレハブ")]
    [SerializeField]public GameObject prefab;

    [Header("召喚間隔（秒）")]
    [SerializeReference]public float spawnInterval = 2f;

    [Header("召喚位置")]
    [SerializeField]public Transform spawnPoint;

    private float timer;

    void Update()
    {
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


