using Items;

namespace Inventory {
public class InventoryEventArgs {
	public ItemData item;
	public uint count;
	public uint previousCount;

	public InventoryEventArgs(ItemData item, uint count, uint previousCount) {
		this.item = item;
		this.count = count;
		this.previousCount = previousCount;
	}
}
}