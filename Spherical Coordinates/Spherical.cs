using System;
using UnityEngine;

[Serializable]
public struct Spherical
{
	[SerializeField] public float radius, polarAngles, elevationAngles;

	public Spherical(float r, float p, float a)
	{
		radius = r;
		polarAngles = p;
		elevationAngles = a;
	}
	public Vector3 ToCartesian()
	{
		float polar = polarAngles / 180f * Mathf.PI;
		float elevation = elevationAngles / 180f * Mathf.PI;

		float a = radius * Mathf.Cos(elevation);

		Vector3 outCart = Vector3.zero;
		outCart.x = a * Mathf.Cos(polar);
		outCart.y = radius * Mathf.Sin(elevation);
		outCart.z = a * Mathf.Sin(polar);
		return outCart;
	}
	
	public static Spherical operator+(Spherical sph, Vector3 vec)
	{
		return new Spherical(sph.radius + vec.x, sph.polarAngles + vec.y, sph.elevationAngles +vec.z);
	}
	
}