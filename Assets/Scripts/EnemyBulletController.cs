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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 v = player.transform.position - this.transform.position;
        v = v.normalized * m_speed;

        // ���x�x�N�g�����Z�b�g����
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = v;
    }
    void OnCollisionEnter(Collision collision)
    {
        // �^�O�� "KillWall" �܂��� ���g�� "Enemy" �^�O�̏ꍇ�Ɏ��g��j��
        if (collision.gameObject.CompareTag("KillWall"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            
        }

    }
}