using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManeg : MonoBehaviour
{
    public static float Score = 0;

    public void AddScore(float value)
    {
        Score += value;
    }
}
