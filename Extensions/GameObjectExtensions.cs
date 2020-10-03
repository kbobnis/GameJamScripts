using UnityEngine;
using System.Collections;
using System;

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

	public static GameObject AddChildFromPrefab(this GameObject container, GameObject prefab, bool stretchAnchors = false) {
		GameObject go = GameObject.Instantiate(prefab) as GameObject;
		go.transform.SetParent(container.transform);
		go.transform.localScale = new Vector3(1, 1, 1);
		if (stretchAnchors) {
			RectTransform rt = go.GetComponent<RectTransform>();
			rt.SetSize(container.GetComponent<RectTransform>().GetSize());
		}
		go.SetActive(true);
		return go;
	}

	public static T GetElementByName<T>(this GameObject go, string name) where T : Component {
		foreach (Transform t in go.GetComponentsInChildren<Transform>(true)) {
			if (t.gameObject.name == name) {
				return t.GetComponent<T>();
			}
		}
		throw new Exception("Child " + name + " not found in " + go.name);
	}

	public static GameObject GetElementByName(this GameObject go, string name) {
		foreach (Transform t in go.GetComponentsInChildren<Transform>(true)) {
			if (t.gameObject.name == name) {
				return t.gameObject;
			}
		}
		throw new Exception("Child " + name + " not found in " + go.name);
	}

}
