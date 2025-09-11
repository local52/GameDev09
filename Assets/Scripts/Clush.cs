using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clush : MonoBehaviour
{
    private bool _onOff = false;
    private bool _click = false;

    [SerializeField] Slider _slider;
    [SerializeField] Image _crackImage;      // ひび割れ表示用
    [SerializeField] Sprite[] _crackSprites; // 0=なし, 1=小, 2=中, 3=大
    [SerializeField] GameObject _player;     // プレイヤーオブジェクト
    [SerializeField] Animator _anim;         // プレイヤーの移動アニメーション
    [SerializeField] Text _text;             // テキスト表示用のUIテキスト
    [SerializeField] ScoreManeg _scoreManeg; // ★ スコア管理スクリプトを参照

    public float _maxDashPoint = 1;

    float _dashPoint;
    float _currentVelocity = 0;

    private int _stopCount = 0;       // 停止した回数
    private float _totalValue = 0f;   // 5回分の合計値

    void Start()
    {
        _dashPoint = _maxDashPoint;
        _slider.maxValue = _maxDashPoint;
        _slider.value = _maxDashPoint;
        _anim = GetComponent<Animator>();

        if (_crackImage != null)
        {
            _crackImage.sprite = _crackSprites[0];
        }

        if (_text != null)
        {
            _text.text = "粛清準備完了";
        }

        // ★ もしインスペクタで設定してなければ自動取得
        if (_scoreManeg == null)
        {
            _scoreManeg = FindObjectOfType<ScoreManeg>();
        }
    }

    void Update()
    {
        // 入力は Update で検知
        if (Input.GetKeyDown(KeyCode.Mouse0) && _stopCount < 5)
        {
            _click = true;

            Debug.Log("粛清値: " + _slider.value);
            if (_text != null)
                _text.text = "粛清値: " + _slider.value.ToString("F2");

            _anim.SetTrigger("Attack");

            _totalValue += _slider.value;
            _stopCount++;

            if (_stopCount == 5) // ★ ちょうど5回目で判定
            {
                ShowCrack(_totalValue);

                Debug.Log("合計値: " + _totalValue);
                if (_text != null)
                    _text.text = "合計値: " + _totalValue.ToString("F2");

                // ★ スコア加算処理をここで実行
                if (_scoreManeg != null)
                {
                    int addScore = Mathf.RoundToInt(_totalValue * 100); // 合計値を100倍して加算など
                    ScoreManeg.Score += addScore;
                    Debug.Log("スコア加算: " + addScore);
                }
            }

            _click = false;
        }
    }

    void FixedUpdate()
    {
        // スライダーの上下運動
        if (_click == false && _stopCount < 5) // ★ 5回終わったら止める
        {
            if (_onOff == true)
                _dashPoint += 0.1f;
            else
                _dashPoint -= 0.1f;

            if (_dashPoint >= _maxDashPoint) _onOff = false;
            if (_dashPoint <= 0f) _onOff = true;

            float currentDashPT = Mathf.SmoothDamp(
                _slider.value,
                _dashPoint,
                ref _currentVelocity,
                0.3f
            );
            _slider.value = currentDashPT;
        }
    }

    void ShowCrack(float total)
    {
        if (_crackImage == null || _crackSprites.Length < 4) return;

        float avg = total / 5f; // ★ 平均値で判定

        if (avg < 0.2f)
        {
            _crackImage.sprite = _crackSprites[0]; // なし
        }
        else if (avg < 0.5f)
        {
            _crackImage.sprite = _crackSprites[1]; // 小
        }
        else if (avg < 0.75f)
        {
            _crackImage.sprite = _crackSprites[2]; // 中
        }
        else
        {
            _crackImage.sprite = _crackSprites[3]; // 大
        }
    }
}
