using Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
public class InventorySlotUI : MonoBehaviour {
	public TMP_Text itemCount;
	public Image itemIcon;
	private ItemStack stack;
	
	public void SetStack(ItemStack stack) {
		this.stack = stack;
		bool isValid = stack.itemData;
		gameObject.SetActive(isValid);

		if (!isValid) return;
		itemIcon.sprite = stack.itemData.icon;
		itemCount.text = stack.count.ToString();
	}
}
}