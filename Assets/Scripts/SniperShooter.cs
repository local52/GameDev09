using UnityEngine;

public class SniperShooter : MonoBehaviour
{
    [SerializeField] Camera sniperCamera;      // SniperCameraController�����Ă�J����
    [SerializeField] GameObject hitEffect;     // ���e�G�t�F�N�g
    [SerializeField] float checkRadius = 3f;   // ���蔼�a
    [SerializeField] LayerMask hitMask;        // Raycast�p�}�X�N

    bool sniperModeActive = false; // �J�����}�l�[�W������؂�ւ��ʒm�����

    public void SetSniperMode(bool active)
    {
        sniperModeActive = active;
    }

    void Update()
    {
        if (!sniperModeActive) return; // TPS���[�h�̂Ƃ��͌��ĂȂ�

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
