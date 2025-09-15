using UnityEngine;

public class LockOnCameraController : MonoBehaviour
{
    [SerializeField] Transform player;   // プレイヤー
    [SerializeField] float distance = 5f; // プレイヤーからの距離
    [SerializeField] float height = 2f;   // カメラの高さ
    [SerializeField] float smoothSpeed = 5f; // カメラ追従の滑らかさ
    [SerializeField] float lockOnRange = 15f; // ロックオン可能距離

    Transform lockTarget; // ロックオン対象
    bool isLocking = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isLocking) // ロック解除
            {
                isLocking = false;
                lockTarget = null;
            }
            else // ロックオン
            {
                lockTarget = FindClosestEnemy();
                if (lockTarget != null)
                {
                    isLocking = true;
                }
            }
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        if (isLocking && lockTarget != null)
        {
            // プレイヤーの位置 + 高さオフセット
            Vector3 desiredPos = player.position - player.forward * distance + Vector3.up * height;
            transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * smoothSpeed);

            // 敵を注視
            Vector3 dir = (lockTarget.position - transform.position).normalized;
            Quaternion lookRot = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * smoothSpeed);
        }
        else
        {
            // 通常の後方追従カメラ
            Vector3 desiredPos = player.position - player.forward * distance + Vector3.up * height;
            transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * smoothSpeed);

            Quaternion lookRot = Quaternion.LookRotation(player.position + Vector3.up * 1.5f - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * smoothSpeed);
        }
    }

    Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject e in enemies)
        {
            float dist = Vector3.Distance(player.position, e.transform.position);
            if (dist < minDist && dist <= lockOnRange)
            {
                closest = e.transform;
                minDist = dist;
            }
        }
        return closest;
    }
}
