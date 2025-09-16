using UnityEngine;

public class SniperShooter : MonoBehaviour
{
    [SerializeField] Camera sniperCamera;      // SniperCameraControllerがついてるカメラ
    [SerializeField] GameObject hitEffect;     // 着弾エフェクト（SphereやParticle）
    [SerializeField] float checkRadius = 3f;   // 着弾地点の周囲判定半径
    [SerializeField] LayerMask hitMask;        // Raycastで当たり判定するレイヤー

    void Update()
    {
        if (!sniperCamera.enabled) return; // スナイパーモードのみ発射可能

        if (Input.GetMouseButtonDown(0)) // 左クリックで発射
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = new Ray(sniperCamera.transform.position, sniperCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, hitMask))
        {
            Debug.Log($"Hit at {hit.point}");

            // 着弾エフェクト生成
            if (hitEffect != null)
                Instantiate(hitEffect, hit.point, Quaternion.identity);

            // 範囲判定
            Collider[] colliders = Physics.OverlapSphere(hit.point, checkRadius);
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Target"))
                {
                    Debug.Log($"Target hit in area: {col.name}");
                    // TODO: ダメージ処理など
                }
            }
        }
    }
}
