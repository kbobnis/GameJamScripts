using CatAstropheGames;
using UnityEngine;

public class SoundAction : DoAction
{
	[SerializeField] private AudioClip sound;
	protected override void OnTriggerEnter()
	{
		SoundService.Play(sound);
	}

	protected override void OnTriggerExit()
	{
		SoundService.Play(sound);
	}
}