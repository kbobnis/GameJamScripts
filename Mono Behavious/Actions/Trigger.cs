using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour
{
	public Action onTriggerEnter, onTriggerExit;

	void Awake()
	{
		if (!GetComponent<Collider>().isTrigger)
		{
			throw new Exception("Collider attached to trigger must have isTrigger selected.");
		}
	}
	
	private void OnTriggerEnter(Collider other)
	{
		onTriggerEnter.SaveInvoke();
	}

	private void OnTriggerExit(Collider other)
	{
		onTriggerExit.SaveInvoke();
	}
}
