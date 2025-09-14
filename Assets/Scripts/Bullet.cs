using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Range(0f, 50f)] float _acceleration = 2f;
    [SerializeField, Range(0f, 100f)] float _speed = 5f;
    [SerializeField, Range(0f, 100f)] float _damage = 10f;

    Transform _target;
    bool _isLaunched = false; // ���˂��ꂽ���ǂ���

    public void SetDamage(float damage) => _damage = damage;
    public void SetSpeed(float speed) => _speed = speed;
    public void SetAcceleration(float acc) => _acceleration = acc;

    // BossFightManager����Ăяo���āu���ˏ�Ԃɂ���v
    public void Launch()
    {
        _isLaunched = true;
        GameObject enemy = FindClosestEnemy();
        if (enemy != null)
            _target = enemy.transform;
    }

    void Update()
    {
        if (!_isLaunched) return; // �܂����˂���ĂȂ��Ȃ牽�����Ȃ�

        if (_target == null)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
            return;
        }

        // �^�[�Q�b�g�����ɉ�]
        Vector3 dir = (_target.position - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * 5f);

        // ����
        _speed += _acceleration * Time.deltaTime;

        // �ړ�
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject e in enemies)
        {
            float dist = Vector3.Distance(transform.position, e.transform.position);
            if (dist < minDist)
            {
                closest = e;
                minDist = dist;
            }
        }
        return closest;
    }
}
