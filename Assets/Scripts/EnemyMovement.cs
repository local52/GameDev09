using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;
    [SerializeField] float m_time = 0f;
    float m_goTime = 0f; // �e�̏o�����Ԃ��Ǘ����邽�߂̕ϐ�
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        m_goTime += Time.deltaTime;
        if (m_goTime >= m_time)
        {
            if (GameObject.FindGameObjectWithTag("PlayerHead") == null)
            {
                return; // �v���C���[�����Ȃ��ꍇ�͉������Ȃ�
            }
            // ���x�x�N�g�������߂�
            GameObject player = GameObject.FindGameObjectWithTag("PlayerHead");
            Vector3 v = player.transform.position - this.transform.position;
            v = v.normalized * m_speed;

            // ���x�x�N�g�����Z�b�g����
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = v;
            m_goTime = 0f; // �^�C�}�[�����Z�b�g
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // �^�O�� "Bullet" �^�O�̏ꍇ�Ɏ��g��j��
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject); // ���g��j��

        }
    }
}