using UnityEngine;

public class SniperShooter : MonoBehaviour
{
    [SerializeField] Camera sniperCamera;      // SniperCameraController�����Ă�J����
    [SerializeField] GameObject hitEffect;     // ���e�G�t�F�N�g�iSphere��Particle�j
    [SerializeField] float checkRadius = 3f;   // ���e�n�_�̎��͔��蔼�a
    [SerializeField] LayerMask hitMask;        // Raycast�œ����蔻�肷�郌�C���[

    void Update()
    {
        if (!sniperCamera.enabled) return; // �X�i�C�p�[���[�h�̂ݔ��ˉ\

        if (Input.GetMouseButtonDown(0)) // ���N���b�N�Ŕ���
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

            // ���e�G�t�F�N�g����
            if (hitEffect != null)
                Instantiate(hitEffect, hit.point, Quaternion.identity);

            // �͈͔���
            Collider[] colliders = Physics.OverlapSphere(hit.point, checkRadius);
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Target"))
                {
                    Debug.Log($"Target hit in area: {col.name}");
                    // TODO: �_���[�W�����Ȃ�
                }
            }
        }
    }
}
