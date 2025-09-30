using System;
using Items;

namespace Inventory {

[Serializable]
public class InventoryItem {
	public InventoryContainer container;
	public ItemStack itemStack;

	public InventoryItem(InventoryContainer container, ItemStack itemStack = null) {
		this.container = container;
		this.itemStack = itemStack;
	}
}
}