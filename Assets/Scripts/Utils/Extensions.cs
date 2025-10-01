using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;
using static UnityEngine.Quaternion;

/// <summary>
/// A class containing extension methods I often use, includes:
/// Framerate independent smoothing,
/// LINQ style foreach loops,
/// Type casting,
/// Vector2 to degrees
/// </summary>
// ReSharper disable once CheckNamespace
public static class Extensions {
	// The exact same thing as "Mathf.SmoothStep" but replaced the parameters with vector3's, should be built-in
	public static Vector3 SmoothStep(this Vector3 from, Vector3 to, float t) {
		t = Clamp01(t);
		t = -2f * t * t * t + 3f * t * t;
		return to * t + from * (1f - t);
	}
	
	// From here -> https://www.youtube.com/watch?v=LSNQuFEDOyQ
	public static float ExpDecay(this float a, float b, float decay, float deltaTime) {
		return b + (a - b) * Exp(-decay * deltaTime);
	}

	public static Vector2 ExpDecay(this Vector2 a, Vector2 b, float decay, float deltaTime) {
		return b + (a - b) * Exp(-decay * deltaTime);
	}

	public static Vector3 ExpDecay(this Vector3 a, Vector3 b, float decay, float deltaTime) {
		return b + (a - b) * Exp(-decay * deltaTime);
	}
	
	public static Quaternion ExpDecay(this Quaternion a, Quaternion b, float decay, float deltaTime) {
		return Slerp(a, b, Exp(-decay * deltaTime));
	}
	
	/// <summary>
	/// Uses Atan2 but automatically normalizes, switches X and Y, converts to degrees, and rotates by -90deg
	/// </summary>
	/// <param name="vector">A direction vector</param>
	/// <returns>Returns the vector's direction in degrees</returns>
	public static float ToDegrees(this Vector2 vector) {
		vector.Normalize();
		return Atan2(vector.y, vector.x) * Rad2Deg - 90f;
	}

	/// <summary>Executes an action on all elements</summary>
	public static void ForEach<T>(this T[] array, Action<T> action) {
		Array.ForEach(array, action);
	}
	
	/// <summary>Executes an action on all elements</summary>
	public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action) {
		foreach (T item in enumerable) action(item);
	}
	
	/// <returns>Attempts to convert to the desired type</returns>
	public static T TryConvert<T>(this object value) {
		return (T)(object)value?.ToString();
	}
}