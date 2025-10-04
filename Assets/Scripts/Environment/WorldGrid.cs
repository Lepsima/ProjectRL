using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Environment {
public class WorldGrid : MonoBehaviour {
	public static WorldGrid Instance;
	public Tilemap tilemap;

	private void Awake() {
		Instance = this;
	}

	public TileBase GetTileAt(Vector2 position) {
		return tilemap.GetTile(tilemap.WorldToCell(position));
	}
}
}