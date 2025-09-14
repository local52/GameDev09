using UnityEngine;

public class JustGuardManager : MonoBehaviour
{
    // SemiJust：弾をそのまま跳ね返す
    public static void SemiJust(GameObject bullet)
    {
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = -rb.velocity; // 進行方向を反転
        }

        Debug.Log("Semi Just! Bullet reflected.");
    }

    // Just：強化された攻撃に変える
    public static void Just(GameObject bullet)
    {
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = -rb.velocity * 2f; // 速度を2倍にして跳ね返す
        }

        // 例：見た目を変える
        bullet.GetComponent<Renderer>().material.color = Color.red;

        Debug.Log("JUST GUARD!! Super reflect!");
    }
}
