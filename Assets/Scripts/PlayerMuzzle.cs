using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuzzle : MonoBehaviour
{


    [Header("召喚するプレハブ")]
    [SerializeField] public GameObject prefab;

    [Header("召喚間隔（秒）")]
    [SerializeReference] public float spawnInterval = 2f;

    [Header("召喚位置")]
    [SerializeField] public Transform spawnPoint;


    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            if (Input.GetButton("Fire1")) // "Fire1" はデフォルトで左クリックやスペースキーに割り当てられています
            {
                Spawn();
                timer = 0f;// スペースキーが押されたときに召喚
                
            }
        }
    }

    void Spawn()
    {
        // spawnPoint が指定されていなければこのオブジェクトの位置を使用
        Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;
        Instantiate(prefab, position, Quaternion.identity);
    }
}


