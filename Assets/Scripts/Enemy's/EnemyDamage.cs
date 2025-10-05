using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int dañoPorToque;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth vidajugador))
        {
            vidajugador.TomarDaño(dañoPorToque);
        }
    }
}
