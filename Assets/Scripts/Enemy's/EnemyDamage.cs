using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int da�oPorToque;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth vidajugador))
        {
            vidajugador.TomarDa�o(da�oPorToque);
        }
    }
}
