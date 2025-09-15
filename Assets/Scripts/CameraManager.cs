using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] TPSCameraController tpsCamera;   // TPSカメラ制御（必ずアタッチ＆参照設定）
    [SerializeField] LockOnCamera lockOnCamera;      // ロックオンカメラ（クラス名とファイル名を一致させてください）
    [SerializeField] Transform player;               // プレイヤーTransform（Inspectorでセット、未設定なら自動検索）

    Transform currentTarget; // ロックオン対象の敵

    void Start()
    {
        // プレイヤー自動検索（Inspectorにセットしていないときのフォールバック）
        if (player == null)
        {
            var p = GameObject.FindWithTag("Player");
            if (p != null) player = p.transform;
        }

        if (tpsCamera == null) Debug.LogError("CameraManager: tpsCamera が割り当てられていません。Inspectorでセットしてください。");
        if (lockOnCamera == null) Debug.LogError("CameraManager: lockOnCamera が割り当てられていません。Inspectorでセットしてください。");
        if (player == null) Debug.LogError("CameraManager: player が見つかりません。Player に Tag=\"Player\" を付けるか、Inspectorでセットしてください。");

        // 最初はTPSのみ有効
        if (tpsCamera != null) tpsCamera.enabled = true;
        if (lockOnCamera != null) lockOnCamera.enabled = false;
    }

    void Update()
    {
        // ロックオン切替（Tabキー）
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentTarget == null)
            {
                GameObject enemy = FindClosestEnemy();
                if (enemy != null)
                {
                    currentTarget = enemy.transform;
                    SwitchToLockOn();
                }
            }
            else
            {
                currentTarget = null;
                SwitchToTPS();
            }
        }

        // ロックオン中はターゲットをlockOnCameraに渡す
        if (currentTarget != null && lockOnCamera != null && lockOnCamera.enabled)
        {
            lockOnCamera.SetTarget(currentTarget);
        }
    }

    void SwitchToLockOn()
    {
        Debug.Log("Switching to LockOn Camera");
        if (tpsCamera != null) tpsCamera.enabled = false;
        if (lockOnCamera != null) lockOnCamera.enabled = true;
    }

    void SwitchToTPS()
    {
        Debug.Log("Switching to TPS Camera");
        if (tpsCamera != null) tpsCamera.enabled = true;
        if (lockOnCamera != null) lockOnCamera.enabled = false;
    }


    

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float minDist = Mathf.Infinity;
        if (player == null) return null;
        Vector3 pos = player.position;

        foreach (GameObject e in enemies)
        {
            float dist = Vector3.Distance(pos, e.transform.position);
            if (dist < minDist)
            {
                closest = e;
                minDist = dist;
            }
        }
        return closest;
    }
}
