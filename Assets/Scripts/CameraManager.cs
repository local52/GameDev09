using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] TPSCameraController tpsCamera;
    [SerializeField] SniperCameraController sniperCamera;

    void Start()
    {
        // 初期はTPSカメラ有効
        tpsCamera.enabled = true;
        sniperCamera.enabled = false;
    }

    void Update()
    {
        // 右クリックで切り替え
        if (Input.GetMouseButtonDown(1))
        {
            bool sniperMode = !sniperCamera.enabled;
            sniperCamera.enabled = sniperMode;
            tpsCamera.enabled = !sniperMode;
        }
    }
}
