using JetBrains.Annotations;
using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action<int> OnPlayerDamaged;
    public Action<int> OnPlayerHealed;

    [SerializeField] private int maxHealth;
    [SerializeField] private int health;

    private void Awake() {
        health = maxHealth;
    }

    public void Damage(int amount) {
        health = Mathf.Clamp(health - amount,0, maxHealth);
        OnPlayerDamaged?.Invoke(health);

        if (health > 0) return;
        
        Destroy(gameObject);
        UnityEditor.EditorApplication.isPlaying = false;

    }

    public void Heal(int amount) { 
        health = Mathf.Clamp(health + amount, 0, maxHealth);
        OnPlayerHealed?.Invoke(health);
    }

    public int GetMaxHealth() => maxHealth;

    public int GetHealth() => health;
}
