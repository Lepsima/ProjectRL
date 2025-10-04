using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using ParticleInstance = Environment.TerrainParticles.ParticleInstance;

namespace Environment {
public class WalkParticles : MonoBehaviour {
	public Transform particleSpawnPoint;
	private readonly List<ParticleInstance> particleList = new();
	
	private void Update() {
		for (int i = particleList.Count - 1; i >= 0; i--) {
			if (particleList[i].particles.isPlaying) continue;
			
			TerrainParticles.Return(particleList[i]);
			particleList.RemoveAt(i);
		}
	}
	
	public void Step(TileBase tile) {
		if (!tile) return;
		
		ParticleInstance instance = TerrainParticles.Instance.GetParticles(tile, TerrainParticles.Intensity.Walk);
		if (instance == null) return;
		
		ParticleSystem particles =  instance.particles;
		particles.transform.position = particleSpawnPoint.position;
		particles.Play();
		particleList.Add(instance);
	}
}
}