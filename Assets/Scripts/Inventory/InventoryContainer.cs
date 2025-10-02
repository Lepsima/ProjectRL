using System;
using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;

namespace Inventory {
public class InventoryContainer : MonoBehaviour, IInventory {
	public int slotCount = 7;
	public ItemStack[] initialItems = Array.Empty<ItemStack>();

	public Action<InventoryEventArgs> OnItemValueChanged;
	private readonly List<ItemStack> items = new();

	private uint _startCount;
	private uint _startStack;
	
	private void Awake() {
		if (initialItems.Length > slotCount) {
			Debug.LogError("Inventory container has more initial items than slots");
			return;
		}

		initialItems.ForEach(i => items.Add(i));
	}

	private bool HasEmptySlots() {
		return items.Count < slotCount;
	}

	private IEnumerable<ItemStack> GetMatchingSlots(ItemData item) {
		return items.Where(slot => slot.itemData == item);
	}

	private void StartCheck(ItemStack stack) {
		_startCount = GetItemCount(stack.itemData);
		_startStack = stack.count;
	}

	private void EndCheck(ItemStack stack) {
		if (_startStack == stack.count) return;
		
		uint endCount = GetItemCount(stack.itemData);
		OnItemValueChanged?.Invoke(new InventoryEventArgs(stack.itemData, endCount, _startCount));
	}
	
	public void AddItems(ItemStack other) {
		if (!other.itemData || other.count == 0) return;
		StartCheck(other);
		
		// Add to existing stacks
		foreach (ItemStack stack in GetMatchingSlots(other.itemData)) {
			stack.Give(other);
			
			if (other.count <= 0) {
				break;
			}
		}

		// Create new stacks if needed
		while (other.count > 0 && HasEmptySlots()) {
			items.Add(ItemStack.CreateStackFrom(other));
		}
		
		EndCheck(other);
	}
	
	public void RemoveItems(ItemStack other) {
		if (!other.itemData || other.count == 0) return;
		StartCheck(other);
		
		foreach (ItemStack stack in GetMatchingSlots(other.itemData).Reverse()) {
			stack.Take(other);
			
			// Remove stack if empty's
			if (stack.count <= 0) {
				items.Remove(stack);
			}
		}
		
		EndCheck(other);
	}

	public void SetItemCount(ItemStack other) {
		StartCheck(new ItemStack(other.itemData, 0));
		
		if (_startCount - other.count > 0) RemoveItems(other);
		else AddItems(other);
		
		EndCheck(new ItemStack(other.itemData, 1));
	}

	public uint GetItemCount(ItemData item) {
		return (uint)GetMatchingSlots(item).Sum(stack => stack.count);
	}

	public ItemStack GetStackAt(int index) {
		return index >= items.Count ? new ItemStack(null, 0) : items[index];
	}

	public void ClearItem(ItemData item) {
		StartCheck(new ItemStack(item, 0));
		bool changed = false;
		
		for (int i = items.Count - 1; i >= 0; i--) {
			if (item && items[i].itemData != item) continue;
			changed = true;
			items.RemoveAt(i);
		}
		
		EndCheck(new ItemStack(item, (uint)(changed ? 1 : 0)));
	}
	
	public void ClearAll() {
		if (items.Count == 0) return;
		for (int i = items.Count - 1; i >= 0; i--) items.RemoveAt(i);
		OnItemValueChanged?.Invoke(new InventoryEventArgs(null, 0, 0));
	}
}
}