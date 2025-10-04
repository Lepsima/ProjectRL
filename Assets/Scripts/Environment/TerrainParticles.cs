using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Utils;

namespace Environment {
public class TerrainParticles : MonoBehaviour {
	[Serializable]
	public class ParticleSet {
		public ParticleSystem walkParticles;
		public ParticleSystem impactParticles;
		public TileBase[] tiles;

		public void CreatePools() {
			ParticlePoolManager.CreatePool(walkParticles);
		}

		public ParticleSystem GetSystem(Intensity intensity) {
			return intensity switch {
				Intensity.Walk => walkParticles,
				Intensity.Impact => impactParticles,
				_ => null
			};
		}
	}

	public class ParticleInstance {
		public readonly ParticleSystem particles;
		public readonly ParticleSystem prefab;

		public ParticleInstance(ParticleSystem prefab) {
			particles = ParticlePoolManager.Get(prefab);
			this.prefab = prefab;
		}
	}

	public enum Intensity {
		Walk,
		Impact
	}

	public static TerrainParticles Instance;
	
	public ParticleSet[] sets;
	private readonly Dictionary<TileBase, int> tileMap = new();

	private void Awake() {
		Instance = this;
		
		for (int i = 0; i < sets.Length; i++) {
			int index = i;
			ParticleSet set = sets[index];
			
			set.CreatePools();
			set.tiles.ForEach(tile => tileMap.Add(tile, index));
		}
	}
	
	public ParticleInstance GetParticles(TileBase tile, Intensity intensity) {
		if (!tileMap.TryGetValue(tile, out int index)) return null;
		
		ParticleSet set = sets[index];
		return new ParticleInstance(set.GetSystem(intensity));
	}

	public static void Return(ParticleInstance instance) {
		ParticlePoolManager.Return(instance.prefab, instance.particles);
	}
}
}