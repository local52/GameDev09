using UnityEngine;
using UnityEngine.UI;

public class ResultTextController : MonoBehaviour
{
    [SerializeField] private Text resultText1; // ����̏l���l
    [SerializeField] private Text resultText2; // ���b�Z�[�W

    [Header("�X�R�A臒l")]
    [SerializeField] private float threshold1 = 1000f; // �u��ɂɁI�v�̃{�[�_�[
    [SerializeField] private float threshold2 = 500f;  // �u�l�ނ��������܂����v�̃{�[�_�[

    void Start()
    {
        float score = ScoreManeg.Score; // static�Ŏ擾

        // 1�ڂ̃e�L�X�g
        if (resultText1 != null)
        {
            resultText1.text = "�������̏l���l�� " + score.ToString("F0") + " �ł��B";
        }

        // 2�ڂ̃e�L�X�g�i�X�R�A�ɉ����ĕ���j
        if (resultText2 != null)
        {
            if (score >= threshold1)
            {
                resultText2.text = "���Ȃ��̘r�͑f���炵���I���Г�ɂɁI";
            }
            else if (score >= threshold2)
            {
                resultText2.text = "�l�ނ��������܂����ˁI�ƂĂ������I";
            }
            else
            {
                resultText2.text = "���Ȃ��̌���S�͂��΂炵���I�����ƍs���܂��傤�I";
            }
        }
    }
}
