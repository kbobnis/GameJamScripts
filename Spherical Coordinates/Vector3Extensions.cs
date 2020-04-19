using UnityEngine;
using System.Collections;

public static class Vector3Extensions {

	public static Vector3 SphericalToCartesian(this Vector3 spherical) {
		return SphericalToCartesian(spherical.x, spherical.y, spherical.z);
	}

	private static Vector3 SphericalToCartesian(float radius, float polarAngles, float elevationAngles) {
		float polar = polarAngles / 180f * Mathf.PI;
		float elevation = elevationAngles / 180f * Mathf.PI;

		float a = radius * Mathf.Cos(elevation);

		Vector3 outCart = Vector3.zero;
		outCart.x = a * Mathf.Cos(polar);
		outCart.y = radius * Mathf.Sin(elevation);
		outCart.z = a * Mathf.Sin(polar);
		return outCart;
	}
}
