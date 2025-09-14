using UnityEngine;

public class JustGuardManager : MonoBehaviour
{
    // SemiJust�F�e�����̂܂ܒ��˕Ԃ�
    public static void SemiJust(GameObject bullet)
    {
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = -rb.velocity; // �i�s�����𔽓]
        }

        Debug.Log("Semi Just! Bullet reflected.");
    }

    // Just�F�������ꂽ�U���ɕς���
    public static void Just(GameObject bullet)
    {
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = -rb.velocity * 2f; // ���x��2�{�ɂ��Ē��˕Ԃ�
        }

        // ��F�����ڂ�ς���
        bullet.GetComponent<Renderer>().material.color = Color.red;

        Debug.Log("JUST GUARD!! Super reflect!");
    }
}
