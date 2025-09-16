using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] TPSCameraController tpsCamera;
    [SerializeField] SniperCameraController sniperCamera;

    void Start()
    {
        // ������TPS�J�����L��
        tpsCamera.enabled = true;
        sniperCamera.enabled = false;
    }

    void Update()
    {
        // �E�N���b�N�Ő؂�ւ�
        if (Input.GetMouseButtonDown(1))
        {
            bool sniperMode = !sniperCamera.enabled;
            sniperCamera.enabled = sniperMode;
            tpsCamera.enabled = !sniperMode;
        }
    }
}
