using UnityEngine;
using UnityEngine.UI; // ← UI.Text を使うなら必要（TextMeshProを使うなら using TMPro; に変える）

public class SniperShooter : MonoBehaviour
{
    [SerializeField] Camera sniperCamera;      // SniperCameraControllerがついてるカメラ
    [SerializeField] GameObject hitEffect;     // 着弾エフェクト
    [SerializeField] float checkRadius = 3f;   // 判定半径
    [SerializeField] LayerMask hitMask;        // Raycast用マスク
    [SerializeField] float scoreValue = 10f;   // 🔽 ヒット時に加算するスコア（インスペクターで設定可能）
    [SerializeField] Text scoreText;           // 🔽 スコア表示用UI（TextMeshProを使うなら TextMeshProUGUI に変える）

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

        // 🔽 毎フレームUIにスコアを反映
        if (scoreText != null)
        {
            scoreText.text = $"Score: {ScoreManeg.Score}";
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

                    // 🔽 ScoreManegを使ってスコア加算
                    ScoreManeg.Score += scoreValue;
                }
            }
        }
    }
}
