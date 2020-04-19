using UnityEngine;

namespace CatAstropheGames
{
	public class DestroyIn : MonoBehaviour
	{
		private float? destroyTime;
        
		public void Initialize(float seconds)
		{
			destroyTime = Time.realtimeSinceStartup + seconds;
		}

		private void Update()
		{
			if (destroyTime != null)
			{
				if (Time.realtimeSinceStartup >= destroyTime)
				{
					Destroy(this.gameObject);
				}
			}
		}
	}
}