using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    void Start()
    {
        // NavMeshAgent を取得
        agent = GetComponent<NavMeshAgent>();

        // プレイヤーを探す（タグで指定）
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
            // プレイヤーの位置に向かって移動
            agent.SetDestination(player.position);
        }
    }
}