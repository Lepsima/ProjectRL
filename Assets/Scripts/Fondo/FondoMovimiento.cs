using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;

    private Vector2 offset;
    private Material material;
    private float lastPositionX;
    
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        float velocity = transform.position.x - lastPositionX;
        lastPositionX = transform.position.x;
        material.mainTextureOffset += velocidadMovimiento * (velocity * 0.1f * Time.deltaTime);
    }
}
