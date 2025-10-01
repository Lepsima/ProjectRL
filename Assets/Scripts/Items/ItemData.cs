using UnityEngine;

namespace Items {
[CreateAssetMenu(fileName = "New Item", menuName = "Item", order = -1000)]
public class ItemData : ScriptableObject {
	public new string name;
	public uint stackSize;
	public Sprite icon;

	[Space]
	public float frameTime;
	public Sprite[] frames;
}
}