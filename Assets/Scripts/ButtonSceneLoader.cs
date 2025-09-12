using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    [Header("ロードするシーン名を指定")]
    [SerializeField] private string sceneName;

    // UIボタンから呼び出すメソッド
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            Debug.Log("▶ シーン遷移: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("⚠ シーン名が設定されていません！");
        }
    }
}
