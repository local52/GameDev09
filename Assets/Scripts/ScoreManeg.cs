using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManeg : MonoBehaviour
{
    // �� static�łǂ�����ł��Q�Ɖ\
    public static float Score = 0;

    [SerializeField] public float _score = 0;

    void Start()
    {
        // �� GameManager �̃X�R�A�������p��
        _score = GameManager.Instance.Score;
        Score = _score;
    }

    public void AddScore(float value)
    {
        _score += value;
        Score = _score; // static�ɂ����f
    }
}
