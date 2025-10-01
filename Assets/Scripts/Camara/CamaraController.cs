using UnityEngine;

public class CamaraController : MonoBehaviour
{
    //Variables
    public Transform objetivo;
    public float velocidadCamara;
    public Vector3 desplazamiento;

    private void LateUpdate()
    {
        Vector3 posiciondeseada = objetivo.position + desplazamiento;

        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posiciondeseada, velocidadCamara);

        transform.position = posicionSuavizada;
    }

}
