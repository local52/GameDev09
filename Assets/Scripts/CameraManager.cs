using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] TPSCameraController tpsCamera;
    [SerializeField] SniperCameraController sniperCamera;
    [SerializeField] SniperShooter sniperShooter;

    void Start()
    {
        tpsCamera.enabled = true;
        sniperCamera.enabled = false;
        if (sniperShooter != null) sniperShooter.SetSniperMode(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            bool sniperMode = !sniperCamera.enabled;
            sniperCamera.enabled = sniperMode;
            tpsCamera.enabled = !sniperMode;

            if (sniperShooter != null)
                sniperShooter.SetSniperMode(sniperMode);
        }
    }
}
