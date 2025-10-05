using Entities;
using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private int healAmount;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.TryGetComponent(out IDamageable damageable)) return;
        
        damageable.Heal(healAmount);
        Destroy(gameObject);
    }
}
