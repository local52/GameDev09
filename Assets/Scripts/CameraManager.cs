using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] TPSCameraController tpsCamera;   // TPS�J��������i�K���A�^�b�`���Q�Ɛݒ�j
    [SerializeField] LockOnCamera lockOnCamera;      // ���b�N�I���J�����i�N���X���ƃt�@�C��������v�����Ă��������j
    [SerializeField] Transform player;               // �v���C���[Transform�iInspector�ŃZ�b�g�A���ݒ�Ȃ玩�������j

    Transform currentTarget; // ���b�N�I���Ώۂ̓G

    void Start()
    {
        // �v���C���[���������iInspector�ɃZ�b�g���Ă��Ȃ��Ƃ��̃t�H�[���o�b�N�j
        if (player == null)
        {
            var p = GameObject.FindWithTag("Player");
            if (p != null) player = p.transform;
        }

        if (tpsCamera == null) Debug.LogError("CameraManager: tpsCamera �����蓖�Ă��Ă��܂���BInspector�ŃZ�b�g���Ă��������B");
        if (lockOnCamera == null) Debug.LogError("CameraManager: lockOnCamera �����蓖�Ă��Ă��܂���BInspector�ŃZ�b�g���Ă��������B");
        if (player == null) Debug.LogError("CameraManager: player ��������܂���BPlayer �� Tag=\"Player\" ��t���邩�AInspector�ŃZ�b�g���Ă��������B");

        // �ŏ���TPS�̂ݗL��
        if (tpsCamera != null) tpsCamera.enabled = true;
        if (lockOnCamera != null) lockOnCamera.enabled = false;
    }

    void Update()
    {
        // ���b�N�I���ؑցiTab�L�[�j
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

        // ���b�N�I�����̓^�[�Q�b�g��lockOnCamera�ɓn��
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
