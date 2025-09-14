using UnityEngine;

public class JustGuardManager : MonoBehaviour
{
    // SemiJustF’e‚ğ‚»‚Ì‚Ü‚Ü”½“]
    public static void SemiJust(GameObject bullet, Transform shield)
    {
        var b = bullet.GetComponent<EnemyZldBullet>();
        if (b != null)
        {
            b.Reflect(-bullet.transform.forward, 1f, Color.white); // is•ûŒü‚ğ”½“]
        }

        Debug.Log("Semi Just! Bullet reflected.");
    }

    // JustF‹­‰»‚³‚ê‚½UŒ‚‚É•Ï‚¦‚é
    public static void Just(GameObject bullet, Transform shield)
    {
        var b = bullet.GetComponent<EnemyZldBullet>();
        if (b != null)
        {
            b.Reflect(shield.forward, 2f, Color.red); // ‚‚ÌŒü‚«‚É‹­‰»’e‚Æ‚µ‚Ä”ò‚Î‚·
        }

        Debug.Log("JUST GUARD!! Super reflect!");
    }
}
