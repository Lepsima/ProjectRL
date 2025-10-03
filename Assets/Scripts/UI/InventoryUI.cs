using System;
using Inventory;
using Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI {

/// <summary>
/// Displays the whole contents of an inventory and provides interaction methods
/// </summary>
public class InventoryUI : MonoBehaviour {
	public static InventoryUI Instance;
	
	public InventoryContainer inventory;
	public Transform slotParent;
	public GameObject slotPrefab;

	[Space] 
	public TMP_Text itemName;
	public TMP_Text itemCount;
	public TMP_Text itemInfo;
	public Image itemImage;
	
	[Space]
	public InventoryWidgetUI[] widgetsToDeactivate;
	private InventorySlotUI[] slots;
	private InventorySlotUI selectedSlot;
	
	private void Awake() {
		Instance = this;
		inventory.OnItemValueChanged += OnInventoryUpdated;
		slots = new InventorySlotUI[inventory.slotCount];

		for (int i = 0; i < inventory.slotCount; i++) {
			slots[i] = Instantiate(slotPrefab, slotParent).GetComponent<InventorySlotUI>();
		}
		
		gameObject.SetActive(false);
	}
	
	private void OnInventoryUpdated(InventoryEventArgs eventArgs) {
		for (int i = 0; i < inventory.slotCount; i++) {
			slots[i].SetStack(inventory.GetStackAt(i));
		}
	}

	public void SelectSlot(InventorySlotUI slot) {
		selectedSlot = Equals(selectedSlot, slot) ? null : slot;
		if (!selectedSlot) return;
		
		itemName.text = slot.stack.itemData.name;
		itemInfo.text = slot.stack.itemData.info;
		itemCount.text = slot.stack.count + "";
		itemImage.sprite = slot.stack.itemData.icon;
	}

	public static void ToggleUI() {
		bool state = !Instance.gameObject.activeSelf;
		Instance.gameObject.SetActive(state);
		Instance.widgetsToDeactivate.ForEach(widget => widget.gameObject.SetActive(!state));
	}
}
}