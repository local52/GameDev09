using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBasedSceneLoader3 : MonoBehaviour
{
    [Header("スコアの閾値を設定")]
    [SerializeField] private float lowScoreThreshold = 30f;   // この値未満なら Low シーン
    [SerializeField] private float highScoreThreshold = 70f;  // この値以上なら High シーン

    [Header("スコアが閾値未満のときのシーン名")]
    [SerializeField] private string lowScoreScene;

    [Header("スコアが閾値の間のときのシーン名")]
    [SerializeField] private string midScoreScene;

    [Header("スコアが高スコア閾値以上のときのシーン名")]
    [SerializeField] private string highScoreScene;

    // UIボタンから呼び出すメソッド
    public void LoadSceneBasedOnScore()
    {
        float currentScore = ScoreManeg.Score;
        Debug.Log("▶ 現在スコア: " + currentScore);

        if (currentScore < lowScoreThreshold)
        {
            LoadScene(lowScoreScene, "Low");
        }
        else if (currentScore < highScoreThreshold)
        {
            LoadScene(midScoreScene, "Mid");
        }
        else
        {
            LoadScene(highScoreScene, "High");
        }
    }

    private void LoadScene(string sceneName, string label)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            Debug.Log($"▶ {label} スコア: シーン遷移 -> {sceneName}");
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning($"⚠ {label} シーン名が設定されていません！");
        }
    }
}
