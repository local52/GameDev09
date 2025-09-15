using UnityEngine;

public class LockOnCameraController : MonoBehaviour
{
    [SerializeField] Transform player;   // �v���C���[
    [SerializeField] float distance = 5f; // �v���C���[����̋���
    [SerializeField] float height = 2f;   // �J�����̍���
    [SerializeField] float smoothSpeed = 5f; // �J�����Ǐ]�̊��炩��
    [SerializeField] float lockOnRange = 15f; // ���b�N�I���\����

    Transform lockTarget; // ���b�N�I���Ώ�
    bool isLocking = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isLocking) // ���b�N����
            {
                isLocking = false;
                lockTarget = null;
            }
            else // ���b�N�I��
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
            // �v���C���[�̈ʒu + �����I�t�Z�b�g
            Vector3 desiredPos = player.position - player.forward * distance + Vector3.up * height;
            transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * smoothSpeed);

            // �G�𒍎�
            Vector3 dir = (lockTarget.position - transform.position).normalized;
            Quaternion lookRot = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * smoothSpeed);
        }
        else
        {
            // �ʏ�̌���Ǐ]�J����
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
