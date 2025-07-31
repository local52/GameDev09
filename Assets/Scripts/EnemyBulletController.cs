using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̒e�𐧌䂷��R���|�[�l���g
/// �o�����̃v���C���[�̈ʒu�����o���āA���̕����ɓ��������^������
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;

    void Start()
    {
        // ���x�x�N�g�������߂�
        GameObject player = GameObject.FindGameObjectWithTag("PlayerHead");
        Vector2 v = player.transform.position - this.transform.position;
        v = v.normalized * m_speed;

        // ���x�x�N�g�����Z�b�g����
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = v;
    }
}