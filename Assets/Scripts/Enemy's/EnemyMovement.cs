using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Variables
    public Transform player;
    public float detectionRadius = 2.0f;
    public float speed;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update() {
        // Player detection
        float distanceToPlayer = Vector2.Distance(transform.position,player.position);

        if (distanceToPlayer < detectionRadius) {
            Vector2 direction = (player.position - transform.position).normalized;
            movement = new Vector2(direction.x, 0);
        }
        else {
            movement = Vector2.zero;
        }

        // Movement
        rb.MovePosition(rb.position + movement * (speed * Time.deltaTime));
    }
    
    // Debug Gizmos
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,detectionRadius);
    }
}
