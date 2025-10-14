using Entities;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    [SerializeField] private int damageAmount;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.TryGetComponent(out IDamageable damageable)) return;
        
        damageable.Damage(damageAmount);
        Destroy(gameObject);
    }
}
