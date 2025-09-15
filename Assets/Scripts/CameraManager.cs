using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] TPSCameraController tpsCamera;   // TPS�J��������
    [SerializeField] LockOnCameraController lockOnCamera; // ���b�N�I���J��������

    Transform currentTarget; // ���b�N�I���Ώۂ̓G

    void Start()
    {
        // �ŏ���TPS�J�����̂ݗL��
        tpsCamera.enabled = true;
        lockOnCamera.enabled = false;
    }

    void Update()
    {
        // ���b�N�I���ؑցi��FTab�L�[�j
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentTarget == null)
            {
                // �߂��G��T��
                GameObject enemy = FindClosestEnemy();
                if (enemy != null)
                {
                    currentTarget = enemy.transform;
                    SwitchToLockOn();
                }
            }
            else
            {
                // ���b�N����
                currentTarget = null;
                SwitchToTPS();
            }
        }

        // ���b�N�I�����̓^�[�Q�b�g�X�V
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
