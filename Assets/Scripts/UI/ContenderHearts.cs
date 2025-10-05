using System;
using UnityEngine;

public class ContenderHearts : MonoBehaviour
{
    [SerializeField] private HeartUI[] hearts;

    [SerializeField] private PlayerHealth healthplayer;

    private void Start()
    {
        healthplayer = FindFirstObjectByType<PlayerHealth>();

        healthplayer.OnPlayerDamaged += ActivateHearts;
        healthplayer.OnPlayerHealed += ActivateHearts;


        ActivateHearts(healthplayer.GetHealth());
    }

    private void OnDisable()
    {
        healthplayer.OnPlayerDamaged -= ActivateHearts;
        healthplayer.OnPlayerHealed -= ActivateHearts;
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
