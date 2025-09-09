using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManeg : MonoBehaviour
{
    float _score = 0;
    // Start is called before the first frame update
    void Start()
    {
        _score = GameManager.Instance.Score;// ÉXÉRÉAèâä˙âª
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
