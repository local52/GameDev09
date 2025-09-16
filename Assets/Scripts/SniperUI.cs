using UnityEngine;

public class SniperUIManager : MonoBehaviour
{
    [SerializeField] GameObject sniperUI; // �X�i�C�p�[UI�̐e�I�u�W�F�N�g

    public void ShowSniperUI(bool show)
    {
        if (sniperUI != null)
            sniperUI.SetActive(show);
    }
}
