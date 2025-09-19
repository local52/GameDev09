using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuzzle : MonoBehaviour
{


    [Header("��������v���n�u")]
    [SerializeField] public GameObject prefab;

    [Header("�����Ԋu�i�b�j")]
    [SerializeReference] public float spawnInterval = 2f;

    [Header("�����ʒu")]
    [SerializeField] public Transform spawnPoint;


    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            if (Input.GetButton("Fire1")) // "Fire1" �̓f�t�H���g�ō��N���b�N��X�y�[�X�L�[�Ɋ��蓖�Ă��Ă��܂�
            {
                Spawn();
                timer = 0f;// �X�y�[�X�L�[�������ꂽ�Ƃ��ɏ���
                
            }
        }
    }

    void Spawn()
    {
        // spawnPoint ���w�肳��Ă��Ȃ���΂��̃I�u�W�F�N�g�̈ʒu���g�p
        Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;
        Instantiate(prefab, position, Quaternion.identity);
    }
}


