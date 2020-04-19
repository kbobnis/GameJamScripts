using System;
using UnityEngine;

public abstract class DoAction : MonoBehaviour
{
	[SerializeField] private Trigger trigger;
	[SerializeField] private bool onTriggerEnter;
	[SerializeField] private bool onTriggerExit;

	protected abstract void OnTriggerEnter();
	protected abstract void OnTriggerExit();

	private void Awake()
	{
		trigger.onTriggerEnter += () =>
		{
			if (onTriggerEnter)
			{
				OnTriggerEnter();
			}
		};
		trigger.onTriggerExit += () =>
		{
			if (onTriggerExit)
			{
				OnTriggerExit();
			}
		};
	}
}