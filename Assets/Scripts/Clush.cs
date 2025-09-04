using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

public class Clush : MonoBehaviour
{
    private float _upDown;
    private bool _onOff = false;
    private bool _click = false;
    // Start is called before the first frame update
    void Start()
    {

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
    }
}