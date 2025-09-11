using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathSceneLoader : MonoBehaviour
{
    [Header("死亡時に遷移するシーン名")]
    [SerializeField] private string sceneToLoad;

    // プレイヤーが死んだ時に呼び出す
    public void OnPlayerDeath()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            //Debug.Log("💀 プレイヤー死亡 → シーン遷移: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            //    Debug.LogWarning("⚠ 遷移先シーン名が設定されていません！");
        }
    }
}
