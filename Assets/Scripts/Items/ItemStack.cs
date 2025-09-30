using System;

namespace Items {

[Serializable]
public class ItemStack {
	public ItemData itemData;
	public uint count;

	public ItemStack(ItemData itemData, uint count) {
		this.itemData = itemData;
		this.count = count;
	}
}
}