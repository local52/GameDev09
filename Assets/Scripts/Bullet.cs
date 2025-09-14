using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Range(0f, 50f)] float _acceleration = 2f;
    [SerializeField, Range(0f, 100f)] float _speed = 5f;
    [SerializeField, Range(0f, 100f)] float _damage = 10f;

    Transform _target;
    bool _isLaunched = false; // 発射されたかどうか

    public void SetDamage(float damage) => _damage = damage;
    public void SetSpeed(float speed) => _speed = speed;
    public void SetAcceleration(float acc) => _acceleration = acc;

    // BossFightManagerから呼び出して「発射状態にする」
    public void Launch()
    {
        _isLaunched = true;
        GameObject enemy = FindClosestEnemy();
        if (enemy != null)
            _target = enemy.transform;
    }

    void Update()
    {
        if (!_isLaunched) return; // まだ発射されてないなら何もしない

        if (_target == null)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
            return;
        }

        // ターゲット方向に回転
        Vector3 dir = (_target.position - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * 5f);

        // 加速
        _speed += _acceleration * Time.deltaTime;

        // 移動
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
