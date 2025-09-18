using UnityEngine;
using UnityEngine.UI; // TextMeshProを使うなら using TMPro;

public class TimeLimit : MonoBehaviour
{
    [SerializeField] float timeLimit = 60f;   // 制限時間（秒） インスペクターで変更可能
    [SerializeField] Text timerText;          // 制限時間表示用のUI（TextMeshProなら TextMeshProUGUI）

    private float currentTime;
    [SerializeField] GameObject player;       // 制限時間が切れたらDestroyするプレイヤー

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

        // UIに表示
        if (timerText != null)
        {
            timerText.text = $"Time: {currentTime:F1}";
        }

        // 時間切れ処理
        if (currentTime <= 0 && player != null)
        {
            Destroy(player);
        }
    }
}
