using System;
using Inventory;
using Items;
using UnityEngine;

namespace Interactions {
public class ItemDrop : MonoBehaviour {
	public ItemData item;
	public uint amount;
	
	// Animation
	private SpriteRenderer spriteRenderer;
	private float nextFrame;
	private int frame;
	
	private void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		
		// Don't animate if there aren't multiple frames
		if (item.frames == null || item.frames.Length < 2) {
			enabled = false;
		}
		
		nextFrame = Time.time + item.frameTime;
	}

	private void Update() {
		if (!(nextFrame < Time.time)) return;
		
		// Next frame
		nextFrame += item.frameTime;
		frame = (frame + 1) % item.frames.Length;
		
		// Change sprite frame
		spriteRenderer.sprite = item.frames[frame];
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (!collision.TryGetComponent(out IInventory inventory)) return;
		
		// Try to add the amount to the inventory
		ItemStack stack = new(item, amount, false);
		inventory.AddItems(stack);

		// Destroy only when zero amount left
		amount = stack.count;
		if (amount <= 0) Destroy(gameObject);
	}
}
}