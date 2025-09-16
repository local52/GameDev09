using UnityEngine;

public class SniperShooter : MonoBehaviour
{
    [SerializeField] Camera sniperCamera;      // SniperCameraControllerがついてるカメラ
    [SerializeField] GameObject hitEffect;     // 着弾エフェクト
    [SerializeField] float checkRadius = 3f;   // 判定半径
    [SerializeField] LayerMask hitMask;        // Raycast用マスク

    bool sniperModeActive = false; // カメラマネージャから切り替え通知される

    public void SetSniperMode(bool active)
    {
        sniperModeActive = active;
    }

    void Update()
    {
        if (!sniperModeActive) return; // TPSモードのときは撃てない

        if (Input.GetMouseButtonDown(0))
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

            if (hitEffect != null)
                Instantiate(hitEffect, hit.point, Quaternion.identity);

            Collider[] colliders = Physics.OverlapSphere(hit.point, checkRadius);
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Target"))
                {
                    Debug.Log($"Target hit in area: {col.name}");
                }
            }
        }
    }
}
