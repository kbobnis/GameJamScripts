using System.Collections.Generic;
using UnityEngine;

namespace CatAstropheGames
{
	public class SoundService
	{
		private static readonly Dictionary<AudioClip, OneSound> sounds = new Dictionary<AudioClip, OneSound>();

		public static void Play(AudioClip clip)
		{
			float volume = 1f;
			if (clip != null)
			{
				if (!sounds.ContainsKey(clip))
				{
					sounds.Add(clip, new OneSound(clip, volume));
				}

				sounds[clip].PlayAnother();
			}
		}
	}

	public class OneSound
	{
		private readonly AudioClip audioClip;
		private readonly float volume;

		public OneSound(AudioClip ac, float volume)
		{
			audioClip = ac;
			this.volume = volume;
		}

		public void PlayAnother()
		{
			GameObject go = new GameObject("sound clip: " + audioClip.name);
			AudioSource audio = go.AddComponent<AudioSource>();
			audio.volume = volume;
			audio.clip = audioClip;
			audio.spatialBlend = 1f;
			audio.Play();
			go.AddComponent<DestroyIn>().Initialize(audioClip.length);
		}
	}
}