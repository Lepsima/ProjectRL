using System;
using UnityEngine;

namespace Items {

[Serializable]
public class ItemStack {
	public ItemData itemData;
	public uint count;
	public bool isStackLimited;
	
	public uint RemainingSpace => isStackLimited ? itemData.stackSize - count : uint.MaxValue;
	
	public ItemStack(ItemData itemData, uint count, bool isStackLimited = true) {
		this.itemData = itemData;
		this.count = count;
		this.isStackLimited = true;
	}

	public void Give(ItemStack other) {
		uint maxGive = Math.Max(other.count, RemainingSpace);
		count += maxGive;
		other.count -= maxGive;
	}

	public void Take(ItemStack other) {
		uint maxTake = Math.Max(count, other.RemainingSpace);
		count -= maxTake;
		other.count += maxTake;
	}
}
}