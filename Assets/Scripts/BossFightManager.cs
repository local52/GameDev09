using UnityEngine;

public class BossFightManager : MonoBehaviour
{
    [SerializeField] GameObject _iceBulletPrefab;
    [SerializeField] Transform _shootPoint;
    [SerializeField] float _bulletSpeed = 5f;
    [SerializeField] float _acceleration = 2f; // 弾の加速力

    [Header("Charge Settings")]
    [SerializeField] float _maxChargeTime = 3f;   // 最大チャージ時間
    [SerializeField] float _minScale = 1f;        // 最小サイズ
    [SerializeField] float _maxScale = 3f;        // 最大サイズ
    [SerializeField] float _minDamage = 5f;       // 最小ダメージ
    [SerializeField] float _maxDamage = 30f;      // 最大ダメージ

    float _chargeTime = 0f;
    bool _isCharging = false;
    GameObject _chargingBullet; // 手元のチャージ演出用弾

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

            // チャージ用ダミー弾を生成（まだ飛ばない）
            _chargingBullet = Instantiate(_iceBulletPrefab, _shootPoint.position, _shootPoint.rotation, _shootPoint);
            _chargingBullet.transform.localScale = Vector3.one * _minScale;
        }

        // チャージ中
        if (_isCharging && Input.GetKey(KeyCode.Mouse0))
        {
            _chargeTime += Time.deltaTime;
            _chargeTime = Mathf.Min(_chargeTime, _maxChargeTime);

            float t = Mathf.Clamp01(_chargeTime / _maxChargeTime);
            float scale = Mathf.Lerp(_minScale, _maxScale, t);

            // 手元の弾を大きくしていく
            if (_chargingBullet != null)
                _chargingBullet.transform.localScale = Vector3.one * scale;
        }

        // 発射
        if (_isCharging && Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (_chargingBullet != null)
            {
                // 手元から外して実弾にする
                _chargingBullet.transform.SetParent(null);

                // 弾スクリプトにダメージ・速度・加速を渡す
                float t = Mathf.Clamp01(_chargeTime / _maxChargeTime);
                float damage = Mathf.Lerp(_minDamage, _maxDamage, t);

                Bullet bulletScript = _chargingBullet.GetComponent<Bullet>();
                if (bulletScript != null)
                {
                    bulletScript.SetDamage(damage);
                    bulletScript.SetSpeed(_bulletSpeed);
                    bulletScript.SetAcceleration(_acceleration);
                    bulletScript.Launch(); // ← 発射開始！
                }


                // Rigidbody に初速を与える
                Rigidbody rb = _chargingBullet.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.velocity = _shootPoint.forward * _bulletSpeed;

                _chargingBullet = null;
            }

            _isCharging = false;
        }
    }
}
