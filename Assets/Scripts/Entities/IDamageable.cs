using System;

namespace Entities {
public interface IDamageable {
	public Action<IDamageable> OnDamaged { get; set; }
	public Action<IDamageable> OnHealed { get; set; }
	public Action<IDamageable> OnKilled { get; set; }

	public Entity GetEntity();
	public int GetMaxHealth();
	public int GetHealth();
	
	public void Damage(int amount);
	public void Heal(int amount);
	public void SetHealth(int amount);
}
}