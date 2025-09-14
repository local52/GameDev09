using UnityEngine;

public class Bullet : MonoBehaviour
{
    float _damage;

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        // “G‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚éˆ—
        Debug.Log("Hit! Damage: " + _damage);
        Destroy(gameObject);
    }
}
