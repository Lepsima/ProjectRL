using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Variables
    public Transform player;
    public float detectionradius;
    public float speed;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        // Deteccion de Jugador
        float distanceToPlayer = Vector2.Distance(transform.position,player.position);

        if (distanceToPlayer < detectionradius)
        {

            Vector2 direction = (player.position - transform.position).normalized;

            movement = new Vector2(direction.x, 0);
        }
        else
        {
            movement = Vector2.zero;
        }

        //Movimiento
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
    
    // Area de radio
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,detectionradius);
    }
}
