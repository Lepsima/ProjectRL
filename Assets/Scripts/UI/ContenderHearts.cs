using System;
using Entities;
using UnityEngine;

public class ContenderHearts : MonoBehaviour
{
    [SerializeField] private EntityHealth healthplayer;
    [SerializeField] private HeartUI[] hearts;

    private void Start() {
        healthplayer.OnDamaged += OnHealthChange;
        healthplayer.OnHealed += OnHealthChange;
        
        ActivateHearts(healthplayer.GetHealth());
    }

    private void OnDisable() {
        healthplayer.OnDamaged -= OnHealthChange;
        healthplayer.OnHealed -= OnHealthChange;
    }


    private void OnHealthChange(IDamageable damageable) {
        ActivateHearts(damageable.GetHealth());
    }

    private void ActivateHearts(int health) {
        for (int i = 0; i < hearts.Length; i++) {
            if (i < health) {
                hearts[i].is_Active();
            }
            else {
                hearts[i].DisableHeart();
            }
        }
    }
}
