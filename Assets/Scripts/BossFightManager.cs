using UnityEngine;

public class BossFightManager : MonoBehaviour
{
    [SerializeField] GameObject _iceBulletPrefab;
    [SerializeField] Transform _shootPoint;
    [SerializeField] float _bulletSpeed = 5f;

    [Header("Charge Settings")]
    [SerializeField] float _maxChargeTime = 3f;   
    [SerializeField] float _minScale = 1f;        
    [SerializeField] float _maxScale = 3f;       
    [SerializeField] float _minDamage = 5f;       
    [SerializeField] float _maxDamage = 30f;      

    float _chargeTime = 0f;
    bool _isCharging = false;

    void Start()
    {
        if (_shootPoint == null)
            _shootPoint = transform.Find("Muzzle2");
    }

    void Update()
    {
        // チャージ開始
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _isCharging = true;
            _chargeTime = 0f;
        }

        // チャージ中
        if (_isCharging && Input.GetKey(KeyCode.Mouse0))
        {
            _chargeTime += Time.deltaTime;
            _chargeTime = Mathf.Min(_chargeTime, _maxChargeTime);

            
        }

        // 発射
        if (_isCharging && Input.GetKeyUp(KeyCode.Mouse0))
        {
            Shoot();
            _isCharging = false;
        }
    }

    void Shoot()
    {
        // チャージ割合を 0〜1 に正規化
        float t = Mathf.Clamp01(_chargeTime / _maxChargeTime);

        // スケールとダメージを補間
        float scale = Mathf.Lerp(_minScale, _maxScale, t);
        float damage = Mathf.Lerp(_minDamage, _maxDamage, t);

        // 弾生成
        GameObject bullet = Instantiate(_iceBulletPrefab, _shootPoint.position, _shootPoint.rotation);

        // サイズ反映
        bullet.transform.localScale = Vector3.one * scale;

        // Rigidbody に速度を与える
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
            rb.velocity = _shootPoint.forward * _bulletSpeed;

        // 弾にダメージを渡す
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
            bulletScript.SetDamage(damage);

        
    }
}
