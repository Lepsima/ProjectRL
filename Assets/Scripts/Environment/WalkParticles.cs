using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using ParticleInstance = Environment.TerrainParticles.ParticleInstance;

namespace Environment {
public class WalkParticles : MonoBehaviour {
	private readonly List<ParticleInstance> particleList = new();
	
	private void Update() {
		for (int i = particleList.Count - 1; i >= 0; i--) {
			if (!particleList[i].particles.isPlaying) 
				TerrainParticles.Return(particleList[i]);
		}
	}
	
	public void Step(Tile tile) {
		ParticleInstance instance = TerrainParticles.Instance.GetParticles(tile, TerrainParticles.Intensity.Walk);
		instance.particles.Play();
		particleList.Add(instance);
	}
}
}