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
        Vector3 posicionSuavizada = transform.position.ExpDecay(posiciondeseada, velocidadCamara, Time.deltaTime);
        transform.position = posicionSuavizada;
    }

}
