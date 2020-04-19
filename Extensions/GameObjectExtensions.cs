using UnityEngine;
using System.Collections;

public static class GameObjectExtensions {

	public static Bounds CalculateBounds(this GameObject gameObject) {
		Bounds bounds = new Bounds();
		Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();
		if (colliders.Length == 0) {
			throw new System.ArgumentException("There need to be colliders to calculate bounds.");
		}
		foreach (Collider col in colliders) {
			bounds.Encapsulate(col.bounds);
		}
		return bounds;
	}

}
