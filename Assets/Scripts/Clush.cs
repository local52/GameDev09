using UnityEngine;
using UnityEngine.UI;

public class Clush : MonoBehaviour
{
    private bool _onOff = false;
    private bool _click = false;

    [SerializeField] Slider _slider;
    [SerializeField] Image _crackImage;   // �Ђъ���\���p
    [SerializeField] Sprite[] _crackSprites; // 0=�Ȃ�, 1=��, 2=��, 3=��

    public float _maxDashPoint = 5;

    float _dashPoint;
    float _currentVelocity = 0;

    void Start()
    {
        _dashPoint = _maxDashPoint;
        _slider.maxValue = _maxDashPoint;
        _slider.value = _maxDashPoint;

        // �ŏ��͂Ђъ��ꖳ��
        if (_crackImage != null)
        {
            _crackImage.sprite = _crackSprites[0];
        }
    }

    void FixedUpdate()
    {
        // �N���b�N���ꂽ��~�߂�
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _click = true;
            Debug.Log("�~�܂����l: " + _slider.value);

            ShowCrack(_slider.value);
        }

        // �~�܂��ĂȂ��Ƃ������㉺�^��
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

            // �X���[�Y�Ɉړ�
            float currentDashPT = Mathf.SmoothDamp(
                _slider.value,
                _dashPoint,
                ref _currentVelocity,
                0.3f
            );
            _slider.value = currentDashPT;
        }
    }

    void ShowCrack(float value)
    {
        if (_crackImage == null || _crackSprites.Length < 4) return;

        if (value < 1f)
        {
            _crackImage.sprite = _crackSprites[0]; // �Ȃ�
        }
        else if (value < 3f)
        {
            _crackImage.sprite = _crackSprites[1]; // ��
        }
        else if (value < 4.5f)
        {
            _crackImage.sprite = _crackSprites[2]; // ��
        }
        else
        {
            _crackImage.sprite = _crackSprites[3]; // ��
        }
    }
}
