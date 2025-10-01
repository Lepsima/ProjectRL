using Items;

namespace Inventory {
public interface IInventory {

	public void AddItems(ItemStack other);

	public void RemoveItems(ItemStack other);

	public void SetItemCount(ItemStack other);
	
	public uint GetItemCount(ItemData item);
	
	public void ClearItem(ItemData item);

	public void ClearAll();
}
}