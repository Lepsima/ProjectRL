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
    private bool enSuelo;

    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Codigo de Movimiento
        move = Input.GetAxis("Horizontal");
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);

        //Rotacion del personaje
        if(move != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
        }

        //Codigo Salto

        Vector3 position = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capasuelo);
        enSuelo = hit.collider != null;

        if(enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }

}
