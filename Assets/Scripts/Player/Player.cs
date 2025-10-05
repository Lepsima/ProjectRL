using Entities;
using Environment;
using TMPro;
using UI;
using UnityEngine;

public class Player : Entity {
    public float speed = 4.25f;
    public float jumpForce = 5.0f;
    
    [Space]
    public float raycastLength = 0.59f;
    public float stepDistance = 1f;
    
    [Space]
    public LayerMask groundLayer;
    
    private float walkedDistance;
    private bool isGrounded;
    private Rigidbody2D rb2D;
    private WalkParticles walkParticles;

    private void Start() {
        walkParticles = GetComponent<WalkParticles>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    
    private void Update() {
        // Movement
        float direction = Input.GetAxis("Horizontal");
        Vector2 vel = new(direction * speed, rb2D.linearVelocity.y);
        rb2D.linearVelocity = vel;

        
        // Player Rotation
        if(direction != 0) {
            transform.localScale = new Vector3(Mathf.Sign(direction), 1, 1);
        }

        // Ground check
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastLength, groundLayer);
        bool grounded = hit.collider;

        if (grounded) {
            walkedDistance += vel.magnitude * Time.deltaTime;
       
            // Jump
            if (Input.GetKeyDown(KeyCode.Space)) { 
                rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }

        // Spawn step particles
        if (walkedDistance > stepDistance) {
            walkedDistance -= stepDistance;
            walkParticles.Step(WorldGrid.Instance.GetTileAt(transform.position - new Vector3(0f, raycastLength, 0f)));
        }
        
        // Open/Close Inventory UI
        if (Input.GetKeyDown(KeyCode.I)) {
            InventoryUI.ToggleUI();
        }
    }

    public override void Destroy() {
        base.Destroy();
        Application.Quit();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * raycastLength);
    }
}
