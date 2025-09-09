using UnityEngine;
using UnityEngine.UI;

public class Clush : MonoBehaviour
{
    private bool _onOff = false;
    private bool _click = false;

    [SerializeField] Slider _slider;
    [SerializeField] Image _crackImage;   // �Ђъ���\���p
    [SerializeField] Sprite[] _crackSprites; // 0=�Ȃ�, 1=��, 2=��, 3=��
    [SerializeField] GameObject _player; // �v���C���[�I�u�W�F�N�g
    [SerializeField] Animator _anim; // �v���C���[�̈ړ��A�j���[�V����

    public float _maxDashPoint = 1;

    float _dashPoint;
    float _currentVelocity = 0;

    // �� �ǉ�
    private int _stopCount = 0;       // ��~������
    private float _totalValue = 0f;   // 5�񕪂̍��v�l

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

            Debug.Log("�~�܂����l: " + _slider.value);
            _anim.SetTrigger("Attack");

            // �� ���v�ɉ��Z & �񐔃J�E���g
            _totalValue += _slider.value;
            _stopCount++;

            if (_stopCount >= 5)
            {
                // 5�񕪂̍��v�l���画��
                ShowCrack(_totalValue);

                Debug.Log("���v�l: " + _totalValue);

                // ���Z�b�g�i�K�v�Ȃ�j
                _stopCount = 0;
                _totalValue = 0f;
            }

            // ���̏㉺�^�����ĊJ�ł���悤��
            _click = false;
        }

        // �X���C�_�[�̏㉺�^���i�N���b�N���f���ĂȂ��������j
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

    // �� ���v�l�Ŕ��肷��悤�ɕύX
    void ShowCrack(float total)
    {
        if (_crackImage == null || _crackSprites.Length < 4) return;

        // 5�񕪂̍��v�l �� ���ϒl�ɂ��������������₷��
        float avg = total / 5f;

        if (avg < 0.2f)
        {
            _crackImage.sprite = _crackSprites[0]; // �Ȃ�
        }
        else if (avg < 0.5f)
        {
            _crackImage.sprite = _crackSprites[1]; // ��
        }
        else if (avg < 0.75f)
        {
            _crackImage.sprite = _crackSprites[2]; // ��
        }
        else
        {
            _crackImage.sprite = _crackSprites[3]; // ��
        }
    }
}
