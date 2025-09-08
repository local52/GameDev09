using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Clush : MonoBehaviour
{
    private float _upDown;
    private bool _onOff = false;
    private bool _click = false;

    [SerializeField] Slider _slider;
    public float _maxDashPoint = 5;

    float _dashPoint;
    float _currentVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        _dashPoint = _maxDashPoint;
        _slider.maxValue = _maxDashPoint;
        _slider.value = _maxDashPoint;
    }

    // Update is called once per frame
    //async void Update()
    //{
    //    if (Input.GetKey(KeyCode.Mouse0))
    //    {
    //        _click = true; 
    //    }
    //}
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _click = true;
        }

        if (_click == false)
        {

            if (_onOff == true)
            {
                _upDown += 0.1f;
            }
            else
            {
                _upDown -= 0.1f;
            }

            if (_upDown >= 1f)
            {
                _onOff = true;
            }
            if (_upDown <= 0f)
            {
                _onOff = false;
            }
        }
        else
        {
            
        }

        float currentDashPT = Mathf.SmoothDamp(_slider.value, _dashPoint, ref _currentVelocity, 10 * Time.deltaTime);
        _slider.value = currentDashPT;

        if (Input.GetKeyDown(KeyCode.E) && _dashPoint < _maxDashPoint)
        {
            _dashPoint++;
        }

        else if (Input.GetKeyDown(KeyCode.Q) && _dashPoint > 0)
        {
            _dashPoint--;
        }
    }
}