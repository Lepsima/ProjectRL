using System.Collections.Generic;
using UnityEngine;

namespace Utils {
public static class ParticlePoolManager {
	private class Pool {
		private readonly ParticleSystem prefab;
		private readonly Queue<ParticleSystem> pool = new();
		
		public Pool(ParticleSystem prefab) {
			this.prefab = prefab;
		}

		private void Create() {
			Return(Object.Instantiate(prefab));
		}
		
		public ParticleSystem Get() {
			if (pool.Count == 0) Create();
			
			ParticleSystem obj = pool.Dequeue();
			obj.gameObject.SetActive(true);
			
			return obj;
		}

		public void Return(ParticleSystem obj) {
			obj.gameObject.SetActive(false);
			pool.Enqueue(obj);
		}
	}

	private static readonly Dictionary<ParticleSystem, Pool> pools = new();

	public static void CreatePool(ParticleSystem prefab) {
		pools.Add(prefab, new Pool(prefab));
	}

	public static ParticleSystem Get(ParticleSystem prefab) {
		return pools[prefab].Get();
	}

	public static void Return(ParticleSystem prefab, ParticleSystem obj) {
		pools[prefab].Return(obj);
	}
}
}