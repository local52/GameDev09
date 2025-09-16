using UnityEngine;

public class ShieldMoveManeger : MonoBehaviour
{
    private Transform player;
    float _time;

    [SerializeField] Vector3 idleOffset = new Vector3(-1f, 0f, 0f); // �v���C���[���i���j�̈ʒu
    [SerializeField] Vector3 guardOffset = new Vector3(0f, 0f, 1f); // �\�����Ƃ��̑O�̈ʒu
    [SerializeField] float moveSpeed = 10f; // �ړ��X�s�[�h

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        _time += Time.deltaTime;

        // �v���C���[�ɒǏ]
        Vector3 targetPos = player.position + (Input.GetKey(KeyCode.Space) ? guardOffset : idleOffset);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);

        // ��]�����i�O�ɏo�Ă���Ƃ��͑O�����A����ȊO�͉������j
        transform.rotation = Input.GetKey(KeyCode.Space)
            ? Quaternion.Euler(0, 0, 0)   // �O����
            : Quaternion.Euler(0, -90, 0); // ������
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            // Just / SemiJust ����
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
                // �v���C���[�Ƀ_���[�W���������Ă�OK
            }
        }
    }
}
