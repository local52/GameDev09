using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
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
    public float _Kill; // �e�̏o�����Ԃ��Ǘ����邽�߂̕ϐ�

    void Update()
    {
        _timer += Time.deltaTime;
        timer += Time.deltaTime;

        _Kill = GameManager.Instance.KillCount; // �S�̂̃L�������擾
        // ���x���؂�ւ�
        if (_Kill >= 30)
        {
            _versions += 1;
            GameManager.Instance.KillCount = 0; // �L���������Z�b�g
        }




        // �o�[�W�������Ƃ̊Ԋu�ݒ�
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
            spawnInterval = 5; // ���x��0�͏����Ԋu����
        }

        // ��������
        if (timer >= spawnInterval)
        {
            if (_versions >= 0) // ���x��0�ȊO
            {
                Spawn();
            }
            timer = 0f;
        }
    }

    void Spawn()
    {
        {
            // spawnPoint ���w�肳��Ă��Ȃ���΂��̃I�u�W�F�N�g�̈ʒu���g�p
            Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
