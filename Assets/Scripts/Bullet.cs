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
        // �G�Ƀ_���[�W��^���鏈��
        Debug.Log("Hit! Damage: " + _damage);
        Destroy(gameObject);
    }
}
