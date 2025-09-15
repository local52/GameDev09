using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] TPSCameraController tpsCamera;   // TPSカメラ制御
    [SerializeField] LockOnCameraController lockOnCamera; // ロックオンカメラ制御

    Transform currentTarget; // ロックオン対象の敵

    void Start()
    {
        // 最初はTPSカメラのみ有効
        tpsCamera.enabled = true;
        lockOnCamera.enabled = false;
    }

    void Update()
    {
        // ロックオン切替（例：Tabキー）
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentTarget == null)
            {
                // 近い敵を探す
                GameObject enemy = FindClosestEnemy();
                if (enemy != null)
                {
                    currentTarget = enemy.transform;
                    SwitchToLockOn();
                }
            }
            else
            {
                // ロック解除
                currentTarget = null;
                SwitchToTPS();
            }
        }

        // ロックオン中はターゲット更新
        if (currentTarget != null && lockOnCamera.enabled)
        {
            lockOnCamera.SetTarget(currentTarget);
        }
    }

    void SwitchToLockOn()
    {
        tpsCamera.enabled = false;
        lockOnCamera.enabled = true;
    }

    void SwitchToTPS()
    {
        tpsCamera.enabled = true;
        lockOnCamera.enabled = false;
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float minDist = Mathf.Infinity;
        Vector3 pos = tpsCamera.Player.position;

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
