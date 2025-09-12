using UnityEngine;
using UnityEngine.UI;

public class ResultTextController : MonoBehaviour
{
    [SerializeField] private Text resultText1; // 今回の粛清値
    [SerializeField] private Text resultText2; // メッセージ

    [Header("スコア閾値")]
    [SerializeField] private float threshold1 = 1000f; // 「南極に！」のボーダー
    [SerializeField] private float threshold2 = 500f;  // 「人類を脅かせました」のボーダー

    void Start()
    {
        float score = ScoreManeg.Score; // staticで取得

        // 1つ目のテキスト
        if (resultText1 != null)
        {
            resultText1.text = "ただ今の粛清値は " + score.ToString("F0") + " です。";
        }

        // 2つ目のテキスト（スコアに応じて分岐）
        if (resultText2 != null)
        {
            if (score >= threshold1)
            {
                resultText2.text = "あなたの腕は素晴らしい！ぜひ南極に！";
            }
            else if (score >= threshold2)
            {
                resultText2.text = "人類を脅かせましたね！とてもいい！";
            }
            else
            {
                resultText2.text = "あなたの向上心はすばらしい！もっと行きましょう！";
            }
        }
    }
}
