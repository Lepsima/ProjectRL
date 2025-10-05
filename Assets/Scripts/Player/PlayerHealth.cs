using JetBrains.Annotations;
using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public Action<int> PlayerTakesDmg;

    public Action<int> PlayerTakesHealth;

    [SerializeField] private int vidaMaxima;

    [SerializeField] private int vidaActual;

    private void Awake()
    {
        vidaActual = vidaMaxima;
    }

    public void TomarDaño(int daño)
    {
        int vidaTemporal = vidaActual - daño;

        vidaTemporal = Mathf.Clamp(vidaTemporal,0, vidaMaxima);

        vidaActual = vidaTemporal;

        PlayerTakesDmg?.Invoke(vidaActual);

        if(vidaActual <= 0)
        {
            Destroy(gameObject);
            UnityEditor.EditorApplication.isPlaying = false;
        }

    }

    public void CurarVida(int curacion)
    {
        int vidaTemporal = vidaActual + curacion;

        vidaTemporal = Mathf.Clamp(vidaTemporal, 0, vidaMaxima);

        vidaActual = vidaTemporal;

        PlayerTakesHealth?.Invoke(vidaActual);
    }

    public int GetVidaMaxima() => vidaMaxima;

    public int GetVidaActual() => vidaActual;
}
