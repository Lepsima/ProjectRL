using System;
using UnityEngine;

public class ContenderHearts : MonoBehaviour
{
    [SerializeField] private HeartUI[] hearts;

    [SerializeField] private PlayerHealth healthplayer;

    private void Start()
    {
        healthplayer = FindFirstObjectByType<PlayerHealth>();

        healthplayer.PlayerTakesDmg += ActivateHearts;
        healthplayer.PlayerTakesHealth += ActivateHearts;


        ActivateHearts(healthplayer.GetVidaActual());
    }

    private void OnDisable()
    {
        healthplayer.PlayerTakesDmg -= ActivateHearts;
        healthplayer.PlayerTakesHealth -= ActivateHearts;
    }



    private void ActivateHearts(int actualHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < actualHealth)
            {
                hearts[i].is_Active();
            }
            else {
                hearts[i].DisableHeart();
            }
        }
    }
}
