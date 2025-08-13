using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    void Start()
    {
        // NavMeshAgent ���擾
        agent = GetComponent<NavMeshAgent>();

        // �v���C���[��T���i�^�O�Ŏw��j
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            // �v���C���[�̈ʒu�Ɍ������Ĉړ�
            agent.SetDestination(player.position);
        }
    }
}