using UnityEngine;

namespace Items {
[CreateAssetMenu(fileName = "New Item", menuName = "Item", order = -1000)]
public class ItemData : ScriptableObject {
	public new string name;
	public string info;
	public uint stackSize;
}
}