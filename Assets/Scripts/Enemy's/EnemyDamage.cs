using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent(out PlayerHealth player)) {
            player.Damage(damage);
        }
    }
}
