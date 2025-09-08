using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clush : MonoBehaviour
{
    private bool _onOff = false;
    private bool _click = false;

    [SerializeField] Slider _slider;
    public float _maxDashPoint = 5;

    float _dashPoint;
    float _currentVelocity = 0;

    void Start()
    {
        _dashPoint = _maxDashPoint;
        _slider.maxValue = _maxDashPoint;
        _slider.value = _maxDashPoint;
    }

    void FixedUpdate()
    {
        // �N���b�N���ꂽ��~�߂�
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _click = true;
            Debug.Log("�~�܂����l: " + _slider.value);
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
                0.3f // �� �X���[�Y��(�b) �����𒲐�
            );
            _slider.value = currentDashPT;
        }
    }
}
