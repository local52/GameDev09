using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{


    [Header("��������v���n�u")]
    [SerializeField]public GameObject prefab;

    [Header("�����Ԋu�i�b�j")]
    [SerializeReference]public float spawnInterval = 2f;

    [Header("�����ʒu")]
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
        // spawnPoint ���w�肳��Ă��Ȃ���΂��̃I�u�W�F�N�g�̈ʒu���g�p
        Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;
        Instantiate(prefab, position, Quaternion.identity);
    }
}


