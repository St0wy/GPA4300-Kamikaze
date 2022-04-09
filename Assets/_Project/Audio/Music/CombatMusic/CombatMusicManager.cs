using UnityEngine;

namespace Kamikaze.Audio.Music.CombatMusic
{
	public class CombatMusicManager : MonoBehaviour
	{
		private AudioSource audioSource;

		private void Awake()
		{
			audioSource = GetComponent<AudioSource>();
			DontDestroyOnLoad(gameObject);
		}

		private void Update()
		{
			if (audioSource == null) return;

			var laneGo = GameObject.FindGameObjectWithTag("Selectable");
			if (laneGo != null)
			{
				if (!audioSource.isPlaying) audioSource.Play();
				return;
			}

			audioSource.Stop();
		}
	}
}