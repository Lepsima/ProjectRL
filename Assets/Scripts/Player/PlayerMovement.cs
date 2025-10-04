using Environment;
using TMPro;
using UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables movimiento
    public float speed;
    private Rigidbody2D rb2D;
    private float move;

    //Variables Salto
    public float jumpForce;
    public float longitudRaycast;
    public LayerMask capasuelo;
    
    private WalkParticles walkParticles;
    public float stepDistance = 0.5f;
    private float walkedDistance = 0.0f;
    private bool enSuelo;
    
    void Start()
    {
        walkParticles = GetComponent<WalkParticles>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Codigo de Movimiento
        move = Input.GetAxis("Horizontal");
        Vector2 vel = new(move * speed, rb2D.linearVelocity.y);
        rb2D.linearVelocity = vel;

        
        //Rotacion del personaje
        if(move != 0) {
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
        }

        //Codigo Salto
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capasuelo);
        bool grounded = hit.collider;

        if (grounded) {
            walkedDistance += vel.magnitude * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space)) { 
                rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }

        // Spawn step particles
        if (walkedDistance > stepDistance) {
            walkedDistance -= stepDistance;
            walkParticles.Step(WorldGrid.Instance.GetTileAt(transform.position - new Vector3(0f, longitudRaycast, 0f)));
        }
        
        // Open/Close Inventory UI
        if (Input.GetKeyDown(KeyCode.I)) {
            InventoryUI.ToggleUI();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }
}
