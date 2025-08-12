using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �G�̒e�𐧌䂷��R���|�[�l���g
/// �o�����̃v���C���[�̈ʒu�����o���āA���̕����ɓ��������^������
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerBulletController : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;
    [SerializeField] float m_time = 0f;

    void Start()
    {
        // ���x�x�N�g�������߂�
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null)
        {
            Vector3 v = enemy.transform.position - this.transform.position;
            v = v.normalized * m_speed;
            Rigidbody rb1 = GetComponent<Rigidbody>();
            rb1.velocity = v;
        }
        if (enemy == null)
        {
            Vector3 vector3 = Vector3.forward;
            vector3 = vector3.normalized * m_speed;
            Rigidbody rb2 = GetComponent<Rigidbody>();
            rb2.velocity = vector3;
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        // �^�O�� "KillWall" �܂��� ���g�� "Enemy" �^�O�̏ꍇ�Ɏ��g��j��
        if (collision.gameObject.CompareTag("KillWall") || gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        m_time += Time.deltaTime;
        if(m_time >= 5)
        {
            Destroy(gameObject);
        }

    }
}