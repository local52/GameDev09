using UnityEngine;

public class LockOnCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float distance = 5f;
    [SerializeField] float height = 2f;
    [SerializeField] float smoothSpeed = 5f;

    Transform lockTarget;

    private void Awake()
    {
        if (player == null)
        {
            var p = GameObject.FindWithTag("Player");
            if (p != null) player = p.transform;
        }
        if (player == null) Debug.LogError("TPSCameraController: player が見つかりません。Player に Tag=\"Player\" を付けるか、Inspectorでセットしてください。");
    }
    public void SetTarget(Transform target)
    {
        lockTarget = target;
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPos = player.position - player.forward * distance + Vector3.up * height;
        transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * smoothSpeed);

        if (lockTarget != null)
        {
            Vector3 dir = (lockTarget.position - transform.position).normalized;
            Quaternion lookRot = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * smoothSpeed);
        }
        else
        {
            Quaternion lookRot = Quaternion.LookRotation(player.position + Vector3.up * 1.5f - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * smoothSpeed);
        }
    }
}
