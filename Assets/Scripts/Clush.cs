using UnityEngine;
using UnityEngine.UI;

public class Clush : MonoBehaviour
{
    private bool _onOff = false;
    private bool _click = false;

    [SerializeField] Slider _slider;
    [SerializeField] Image _crackImage;   // ひび割れ表示用
    [SerializeField] Sprite[] _crackSprites; // 0=なし, 1=小, 2=中, 3=大
    [SerializeField] GameObject _player; // プレイヤーオブジェクト
    [SerializeField] Animator _anim; // プレイヤーの移動アニメーション

    public float _maxDashPoint = 1;

    float _dashPoint;
    float _currentVelocity = 0;

    // ★ 追加
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
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _click = true;

            Debug.Log("止まった値: " + _slider.value);
            _anim.SetTrigger("Attack");

            // ★ 合計に加算 & 回数カウント
            _totalValue += _slider.value;
            _stopCount++;

            if (_stopCount >= 5)
            {
                // 5回分の合計値から判定
                ShowCrack(_totalValue);

                Debug.Log("合計値: " + _totalValue);

                // リセット（必要なら）
                _stopCount = 0;
                _totalValue = 0f;
            }

            // 次の上下運動を再開できるように
            _click = false;
        }

        // スライダーの上下運動（クリック中断してない時だけ）
        if (_click == false)
        {
            if (_onOff == true)
            {
                _dashPoint += 0.1f;
            }
            else
            {
                _dashPoint -= 0.1f;
            }

            if (_dashPoint >= _maxDashPoint)
            {
                _onOff = false;
            }
            if (_dashPoint <= 0f)
            {
                _onOff = true;
            }

            float currentDashPT = Mathf.SmoothDamp(
                _slider.value,
                _dashPoint,
                ref _currentVelocity,
                0.3f
            );
            _slider.value = currentDashPT;
        }
    }

    // ★ 合計値で判定するように変更
    void ShowCrack(float total)
    {
        if (_crackImage == null || _crackSprites.Length < 4) return;

        // 5回分の合計値 → 平均値にした方が調整しやすい
        float avg = total / 5f;

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
