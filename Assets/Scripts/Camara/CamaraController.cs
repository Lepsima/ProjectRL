using UnityEngine;

public class CamaraController : MonoBehaviour
{
    //Variables
    public Transform objetivo;
    public Transform background;
    public float velocidadCamara;
    public Vector3 desplazamiento;

    private void LateUpdate()
    {
        Vector3 posiciondeseada = objetivo.position + desplazamiento;
        background.position = new Vector3(posiciondeseada.x, 0f, 0f);
        
        Vector3 posicionSuavizada = transform.position.ExpDecay(posiciondeseada, velocidadCamara, Time.deltaTime);
        transform.position = posicionSuavizada;
    }

}
