using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManeg : MonoBehaviour
{
    // ★ staticでどこからでも参照可能
    public static float Score = 0;

    [SerializeField] public float _score = 0;

    void Start()
    {
        // ★ GameManager のスコアを引き継ぎ
        _score = GameManager.Instance.Score;
        Score = _score;
    }

    public void AddScore(float value)
    {
        _score += value;
        Score = _score; // staticにも反映
    }
}
