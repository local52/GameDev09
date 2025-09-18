using UnityEngine;
using UnityEngine.UI; // TextMeshPro���g���Ȃ� using TMPro;

public class TimeLimit : MonoBehaviour
{
    [SerializeField] float timeLimit = 60f;   // �������ԁi�b�j �C���X�y�N�^�[�ŕύX�\
    [SerializeField] Text timerText;          // �������ԕ\���p��UI�iTextMeshPro�Ȃ� TextMeshProUGUI�j

    private float currentTime;
    [SerializeField] GameObject player;       // �������Ԃ��؂ꂽ��Destroy����v���C���[

    void Start()
    {
        currentTime = timeLimit;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0) currentTime = 0;
        }

        // UI�ɕ\��
        if (timerText != null)
        {
            timerText.text = $"Time: {currentTime:F1}";
        }

        // ���Ԑ؂ꏈ��
        if (currentTime <= 0 && player != null)
        {
            Destroy(player);
        }
    }
}
