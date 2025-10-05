using UnityEngine;

namespace Entities {
public class Entity : MonoBehaviour {
	public virtual void Destroy() {
		Destroy(gameObject);
	}
}
}