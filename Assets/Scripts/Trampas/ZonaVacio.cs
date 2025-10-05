using Entities;
using UnityEngine;

public class ZonaVacio : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.TryGetComponent(out IDamageable damageable)) {
            damageable.SetHealth(0);
        }
    }
}
