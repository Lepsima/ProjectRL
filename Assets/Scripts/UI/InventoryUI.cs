using System;
using Inventory;
using Items;
using UnityEngine;

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
	public InventoryWidgetUI[] widgetsToDeactivate;
	private InventorySlotUI[] slots;
	
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

	public static void ToggleUI() {
		bool state = !Instance.gameObject.activeSelf;
		Instance.gameObject.SetActive(state);
		Instance.widgetsToDeactivate.ForEach(widget => widget.gameObject.SetActive(!state));
	}
}
}