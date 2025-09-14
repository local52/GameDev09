using UnityEngine;

public class JustGuardManager : MonoBehaviour
{
    // SemiJust�F�e�����̂܂ܔ��]
    public static void SemiJust(GameObject bullet, Transform shield)
    {
        var b = bullet.GetComponent<EnemyZldBullet>();
        if (b != null)
        {
            b.Reflect(-bullet.transform.forward, 1f, Color.white); // �i�s�����𔽓]
        }

        Debug.Log("Semi Just! Bullet reflected.");
    }

    // Just�F�������ꂽ�U���ɕς���
    public static void Just(GameObject bullet, Transform shield)
    {
        var b = bullet.GetComponent<EnemyZldBullet>();
        if (b != null)
        {
            b.Reflect(shield.forward, 2f, Color.red); // ���̌����ɋ����e�Ƃ��Ĕ�΂�
        }

        Debug.Log("JUST GUARD!! Super reflect!");
    }
}
