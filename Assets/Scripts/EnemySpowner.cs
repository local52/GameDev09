using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpowner : MonoBehaviour
{
    [Header("��������v���n�u")]
    [SerializeField] public GameObject prefab;

    [Header("�����Ԋu�i�b�j")]
    [SerializeReference] public float spawnInterval = 2f;

    [Header("�����ʒu")]
    [SerializeField] public Transform spawnPoint;

    [Header("���x���P�̎�")]
    [SerializeField] public float _1_Interval = 10;
  

    [Header("���x���Q�̎�")]
    [SerializeField] public float _2_Interval = 5;
    

    [Header("���x���R�̎�")]
    [SerializeField] public float _3_Interval = 5;
    

    [Header("�o�[�W�����Ǘ��O�C�P�C�Q")]
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
            _1_Interval = 10f; // ���x��1�̏����Ԋu
        }

        if (_timer >= _interval2 && _versions == 1)
        {
            _2_Interval = 5f; // ���x��2�̏����Ԋu
        }

        if (_timer >= _interval3 && _versions == 2)
        {
            _3_Interval = 2f; // ���x��3�̏����Ԋu
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
        // spawnPoint ���w�肳��Ă��Ȃ���΂��̃I�u�W�F�N�g�̈ʒu���g�p
        Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;
        Instantiate(prefab, position, Quaternion.identity);
    }
}
