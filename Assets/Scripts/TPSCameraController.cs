using UnityEngine;

public class TPSCameraController : MonoBehaviour
{
    [Header("プレイヤー設定")]
    [SerializeField] Transform player;   // プレイヤー
    [SerializeField] Vector3 offset = new Vector3(0, 2f, -4f); // カメラの基準オフセット

    [Header("カメラ回転設定")]
    [SerializeField] float mouseSensitivity = 2f; // マウス感度
    [SerializeField] float minPitch = -20f; // 下向きの制限
    [SerializeField] float maxPitch = 60f;  // 上向きの制限

    float yaw;   // 左右回転
    float pitch; // 上下回転

    void Start()
    {
        // 初期角度を設定
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;

        // マウスカーソルを非表示 & 固定（PC用）
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // 入力でカメラ回転
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // カメラ回転を適用
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // プレイヤーからのオフセット位置
        Vector3 desiredPosition = player.position + rotation * offset;

        transform.position = desiredPosition;
        transform.LookAt(player.position + Vector3.up * 1.5f); // プレイヤーの頭あたりを注視
    }
}
