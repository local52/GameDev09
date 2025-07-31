using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̒e�𐧌䂷��R���|�[�l���g
/// �o�����̃v���C���[�̈ʒu�����o���āA���̕����ɓ��������^������
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerBulletController : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;

    void Start()
    {
        // ���x�x�N�g�������߂�
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        Vector3 v = enemy.transform.position - this.transform.position;
        v = v.normalized * m_speed;

        // ���x�x�N�g�����Z�b�g����
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = v;
    }
}