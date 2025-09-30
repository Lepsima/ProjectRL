using System;
using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Inventory {
public class InventoryContainer : MonoBehaviour {
	public int slots = 7;
	public ItemStack[] initialItems = Array.Empty<ItemStack>();
	
	private InventoryItem[] items;

	private void Awake() {
		items = new InventoryItem[slots];

		if (initialItems.Length > slots) {
			Debug.LogError("Inventory container has more initial items than slots");
			return;
		}
		
		for (int i = 0; i < items.Length; i++) {
			ItemStack stack = i < initialItems.Length ? initialItems[i] : null;
			items[i] = new InventoryItem(this, stack);
		}
	}
}
}