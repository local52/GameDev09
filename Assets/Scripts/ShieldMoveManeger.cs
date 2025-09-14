using UnityEngine;

public class ShieldMoveManeger : MonoBehaviour
{
    private Transform player;
    float _time;

    [SerializeField] Vector3 idleOffset = new Vector3(-1f, 0f, 0f); // プレイヤー横（左）の位置
    [SerializeField] Vector3 guardOffset = new Vector3(0f, 0f, 1f); // 構えたときの前の位置
    [SerializeField] float moveSpeed = 10f; // 移動スピード

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        _time += Time.deltaTime;

        // プレイヤーに追従
        Vector3 targetPos = player.position + (Input.GetKey(KeyCode.Space) ? guardOffset : idleOffset);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);

        // 回転処理（前に出ているときは前向き、それ以外は横向き）
        transform.rotation = Input.GetKey(KeyCode.Space)
            ? Quaternion.Euler(0, 0, 0)   // 前向き
            : Quaternion.Euler(0, -90, 0); // 横向き
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            // Just / SemiJust 判定
            if (_time < 0.1f)
            {
                JustGuardManager.Just(other.gameObject, transform);
                Debug.Log("Guard");
            }
            else if (_time < 0.5f)
            {
                JustGuardManager.SemiJust(other.gameObject, transform);
                Debug.Log("Guard");
            }
            else
            {
                Debug.Log("Guard failed! Player takes damage.");
                // プレイヤーにダメージ処理を入れてもOK
            }
        }
    }
}
