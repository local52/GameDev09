using UnityEngine;

public class SniperCameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset = new Vector3(0, 1.6f, 0); // �v���C���[�̖ڂ̍���
    [SerializeField] float sensitivity = 2f;

    float pitch, yaw;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // �}�E�X�Ŏ��_�ړ�
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -80f, 80f);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);

        // �ʒu���v���C���[�̓��̈ʒu�ɂ���
        transform.position = player.position + offset;
    }
}
