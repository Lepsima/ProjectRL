using System;
using Inventory;
using Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
public class InventoryUIWidget : MonoBehaviour {
	public TMP_Text itemName;
	public TMP_Text itemCount;
	public Image itemIcon;

	[Space]
	public ItemData trackedItem;
	public InventoryContainer inventory;
	
	private void Awake() {
		inventory.OnItemValueChanged += OnInventoryUpdated;
		if (itemName) itemName.text = trackedItem.name;
		if (itemIcon) itemIcon.sprite = trackedItem.icon;
	}

	private void OnInventoryUpdated(InventoryEventArgs eventArgs) {
		if ((!eventArgs.item || eventArgs.item == trackedItem) && itemCount) {
			itemCount.text = eventArgs.count.ToString();
		}
	}
}
}