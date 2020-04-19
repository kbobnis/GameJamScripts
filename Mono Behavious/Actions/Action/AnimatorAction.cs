using UnityEngine;

public class AnimatorAction : DoAction
{
	[SerializeField] private string boolName;
	
	protected override void OnTriggerEnter()
	{
		GetComponent<Animator>().SetBool(boolName, true);
	}

	protected override void OnTriggerExit()
	{
		GetComponent<Animator>().SetBool(boolName, false);
	}
}