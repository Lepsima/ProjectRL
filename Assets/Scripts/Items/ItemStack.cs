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

	public static ItemStack CreateStackFrom(ItemStack source) {
		ItemStack newStack = new(source.itemData, 0);
		newStack.Give(source);
		return newStack;
	}

	public void Give(ItemStack other) {
		uint maxGive = Math.Min(other.count, RemainingSpace);
		count += maxGive;
		other.count -= maxGive;
	}

	public void Take(ItemStack other) {
		uint maxTake = Math.Min(count, other.RemainingSpace);
		count -= maxTake;
		other.count += maxTake;
	}
}
}