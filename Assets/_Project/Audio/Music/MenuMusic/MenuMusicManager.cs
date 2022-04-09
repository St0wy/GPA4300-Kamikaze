using UnityEngine;

namespace Kamikaze.Audio.Music.MenuMusic
{
	public class MenuMusicManager : MonoBehaviour
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
				audioSource.Stop();
				return;
			}

			if (!audioSource.isPlaying) audioSource.Play();
		}
	}
}