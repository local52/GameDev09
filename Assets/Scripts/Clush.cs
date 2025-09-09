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
    [SerializeField] Image _crackImage;      // �Ђъ���\���p
    [SerializeField] Sprite[] _crackSprites; // 0=�Ȃ�, 1=��, 2=��, 3=��
    [SerializeField] GameObject _player;     // �v���C���[�I�u�W�F�N�g
    [SerializeField] Animator _anim;         // �v���C���[�̈ړ��A�j���[�V����
    [SerializeField] Text _text;        //�e�L�X�g�\���p��UI�e�L�X�g

    public float _maxDashPoint = 1;

    float _dashPoint;
    float _currentVelocity = 0;

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

        if (_text != null)
        {
            _text.text = "�l����������";
        }
    }

    void Update()
    {
        // ���͂� Update �Ō��m
        if (Input.GetKeyDown(KeyCode.Mouse0) && _stopCount < 5)
        {
            _click = true;

            Debug.Log("�l���l: " + _slider.value);
            if (_text != null)
                _text.text = "�l���l: " + _slider.value.ToString("F2");

            _anim.SetTrigger("Attack");

            _totalValue += _slider.value;
            _stopCount++;

            if (_stopCount == 5) // �� ���傤��5��ڂŔ���
            {
                ShowCrack(_totalValue);

                Debug.Log("���v�l: " + _totalValue);
                if (_text != null)
                    _text.text = "���v�l: " + _totalValue.ToString("F2");
            }

            _click = false;
        }
    }

    void FixedUpdate()
    {
        // �X���C�_�[�̏㉺�^��
        if (_click == false && _stopCount < 5) // �� 5��I�������~�߂�
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

        float avg = total / 5f; // �� ���ϒl�Ŕ���

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
