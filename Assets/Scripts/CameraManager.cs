using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] TPSCameraController tpsCamera;
    [SerializeField] SniperCameraController sniperCamera;
    [SerializeField] SniperShooter sniperShooter;
    [SerializeField] SniperUIManager sniperUIManager;

    void Start()
    {
        tpsCamera.enabled = true;
        sniperCamera.enabled = false;
        if (sniperShooter != null) sniperShooter.SetSniperMode(false);
        if (sniperUIManager != null) sniperUIManager.ShowSniperUI(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 右クリックで切替
        {
            bool sniperMode = !sniperCamera.enabled;
            sniperCamera.enabled = sniperMode;
            tpsCamera.enabled = !sniperMode;

            if (sniperShooter != null)
                sniperShooter.SetSniperMode(sniperMode);

            if (sniperUIManager != null)
                sniperUIManager.ShowSniperUI(sniperMode);
        }
    }
}
