using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private int curaporToque;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth vidajugador))
        {
            vidajugador.CurarVida(curaporToque);
            Destroy(gameObject);
        }
    }
}
