using UnityEngine;

public class ShieldMoveManeger : MonoBehaviour
{
    private Transform player;
    float _time;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        _time += Time.deltaTime;

        // プレイヤーに追従
        transform.position = player.position;

        // 回転処理
        transform.rotation = Input.GetKey(KeyCode.Space)
            ? Quaternion.Euler(0, -90, 0)
            : Quaternion.Euler(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            // Just / SemiJust 判定
            if (_time > -0.1f && _time < 0.1f)
            {
                JustGuardManager.Just(other.gameObject);
            }
            else if (_time > -0.5f && _time < 0.5f)
            {
                JustGuardManager.SemiJust(other.gameObject);
            }

            // タイミングが外れてたら普通にダメージ受ける、などの処理を入れてもよい
        }
    }
}
