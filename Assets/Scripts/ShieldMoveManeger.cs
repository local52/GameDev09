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

        // �v���C���[�ɒǏ]
        transform.position = player.position;

        // ��]����
        transform.rotation = Input.GetKey(KeyCode.Space)
            ? Quaternion.Euler(0, -90, 0)
            : Quaternion.Euler(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            // Just / SemiJust ����
            if (_time > -0.1f && _time < 0.1f)
            {
                JustGuardManager.Just(other.gameObject);
            }
            else if (_time > -0.5f && _time < 0.5f)
            {
                JustGuardManager.SemiJust(other.gameObject);
            }

            // �^�C�~���O���O��Ă��畁�ʂɃ_���[�W�󂯂�A�Ȃǂ̏��������Ă��悢
        }
    }
}
