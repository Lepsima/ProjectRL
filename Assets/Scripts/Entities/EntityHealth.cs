using System;
using UnityEngine;

namespace Entities {
[RequireComponent(typeof(Entity))]
public class EntityHealth : MonoBehaviour, IDamageable {
	[SerializeField] 
	private int maxHealth = 10;
	
	private int health;
	private Entity entity;
	
	// Events
	public Action<IDamageable> OnDamaged { get; set; }
	public Action<IDamageable> OnHealed { get; set; }
	public Action<IDamageable> OnKilled { get; set; }

	// Properties
	public Entity GetEntity() => entity;
	public int GetMaxHealth() => maxHealth;
	public int GetHealth() => health;
	
	// Damage / Heal
	public void Damage(int amount) => ChangeHealth(-amount);
	public void Heal(int amount) => ChangeHealth(amount);
	public void SetHealth(int amount) => ChangeHealth(amount - health);

	private void Awake() {
		entity = GetComponent<Entity>();
		health = maxHealth;
		OnKilled += OnEntityKilled;
	}

	private void ChangeHealth(int amount) {
		// Change value
		int oldHealth = health;
		health = Mathf.Clamp(health + amount, 0, maxHealth);
		
		// Invoke events
		if (health == 0) OnKilled?.Invoke(this);
		else if (health > oldHealth) OnHealed?.Invoke(this);
		else if (health < oldHealth) OnDamaged?.Invoke(this);
	}

	private static void OnEntityKilled(IDamageable damageable) {
		damageable.GetEntity().Destroy();
	}
}
}