using UnityEngine;

public class TPSCameraController : MonoBehaviour
{
    [Header("�v���C���[�ݒ�")]
    [SerializeField] Transform player;   // �v���C���[
    [SerializeField] Vector3 offset = new Vector3(0, 2f, -4f); // �J�����̊�I�t�Z�b�g

    [Header("�J������]�ݒ�")]
    [SerializeField] float mouseSensitivity = 2f; // �}�E�X���x
    [SerializeField] float minPitch = -20f; // �������̐���
    [SerializeField] float maxPitch = 60f;  // ������̐���

    float yaw;   // ���E��]
    float pitch; // �㉺��]

    void Start()
    {
        // �����p�x��ݒ�
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;

        // �}�E�X�J�[�\�����\�� & �Œ�iPC�p�j
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // ���͂ŃJ������]
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // �J������]��K�p
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // �v���C���[����̃I�t�Z�b�g�ʒu
        Vector3 desiredPosition = player.position + rotation * offset;

        transform.position = desiredPosition;
        transform.LookAt(player.position + Vector3.up * 1.5f); // �v���C���[�̓�������𒍎�
    }
}
