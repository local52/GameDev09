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
        // ƒNƒŠƒbƒN‚³‚ê‚½‚çŽ~‚ß‚é
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _click = true;
            Debug.Log("Ž~‚Ü‚Á‚½’l: " + _slider.value);
        }

        // Ž~‚Ü‚Á‚Ä‚È‚¢‚Æ‚«‚¾‚¯ã‰º‰^“®
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

            // ƒXƒ€[ƒY‚ÉˆÚ“®
            float currentDashPT = Mathf.SmoothDamp(
                _slider.value,
                _dashPoint,
                ref _currentVelocity,
                0.3f // © ƒXƒ€[ƒY‚³(•b) ‚±‚±‚ð’²®
            );
            _slider.value = currentDashPT;
        }
    }
}
