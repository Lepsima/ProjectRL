using System;
using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;

namespace Inventory {
public class InventoryContainer : MonoBehaviour, IInventory {
	public int slots = 7;
	public ItemStack[] initialItems = Array.Empty<ItemStack>();

	private readonly List<ItemStack> items = new();

	private void Awake() {
		if (initialItems.Length > slots) {
			Debug.LogError("Inventory container has more initial items than slots");
			return;
		}
		
		initialItems.ForEach(i => items.Add(i));
	}

	private bool HasEmptySlots() {
		return items.Count < slots;
	}

	private IEnumerable<ItemStack> GetMatchingSlots(ItemData item) {
		return items.Where(slot => slot.itemData == item);
	}
	
	public void AddItems(ItemStack other) { 
		// Add to existing stacks
		foreach (ItemStack stack in GetMatchingSlots(other.itemData)) {
			stack.Give(other);
			
			if (other.count <= 0) {
				return;
			}
		}

		// Create new stacks if needed
		while (other.count > 0 && HasEmptySlots()) {
			uint maxCount = Math.Max(other.itemData.stackSize, other.count);
			items.Add(new ItemStack(other.itemData, maxCount));
		}
	}
	
	public void RemoveItems(ItemStack other) {
		foreach (ItemStack stack in GetMatchingSlots(other.itemData).Reverse()) {
			stack.Take(other);
			
			// Remove stack if empty's
			if (stack.count <= 0) {
				items.Remove(stack);
			}
		}
	}

	public void SetItemCount(ItemStack other) {
		if (GetItemCount(other.itemData) - other.count > 0) RemoveItems(other);
		else AddItems(other);
	}

	public uint GetItemCount(ItemData item) {
		return (uint)GetMatchingSlots(item).Sum(stack => stack.count);
	}
	
	public void ClearItem(ItemData item) {
		for (int i = items.Count - 1; i >= 0; i--) {
			if (!item || items[i].itemData == item) 
				items.RemoveAt(i);
		}
	}
	
	public void ClearAll() {
		ClearItem(null);
	}
}
}