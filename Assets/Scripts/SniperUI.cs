using UnityEngine;

public class SniperUIManager : MonoBehaviour
{
    [SerializeField] GameObject sniperUI; // スナイパーUIの親オブジェクト

    public void ShowSniperUI(bool show)
    {
        if (sniperUI != null)
            sniperUI.SetActive(show);
    }
}
