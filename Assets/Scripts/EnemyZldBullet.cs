using UnityEngine;

public class EnemyZldBullet : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] float _speed = 5f;
    [SerializeField, Range(0f, 50f)] float _acceleration = 2f;
    [SerializeField, Range(0f, 100f)] float _damage = 10f;

    Transform _player;
    bool _isReflected = false; // ���˂��ꂽ���ǂ���

    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            _player = playerObj.transform;
            Vector3 dir = (_player.position - transform.position).normalized;
            transform.forward = dir;
        }
    }

    void Update()
    {
        _speed += _acceleration * Time.deltaTime;
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isReflected)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log($"Hit Player! Damage: {_damage}");
                Destroy(gameObject);
            }
            else if (other.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log($"Hit Enemy! Reflected Damage: {_damage}");
                Destroy(gameObject);
            }
            else if (other.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// ������Ă΂�Ĕ��ˏ�Ԃɓ���
    /// </summary>
    public void Reflect(Vector3 newDir, float powerMultiplier, Color newColor)
    {
        _isReflected = true;
        transform.forward = newDir;         // �V�����i�s�����i����forward�Ȃǁj
        _speed *= powerMultiplier;          // �З͋���
        _damage *= powerMultiplier;         // �_���[�W������

        // �����ڂ�ς���
        var renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = newColor;
        }

        Debug.Log("Bullet Reflected!");
    }
}
