using UnityEngine;

namespace Kamikaze.Audio.Music.MenuMusic
{
	public class MenuMusicSpawner : MonoBehaviour
	{
		[SerializeField] private GameObject menuMusicPrefab;

		private void Awake()
		{
			var musicManager = FindObjectOfType<MenuMusicManager>();
			if (musicManager == null)
			{
				Instantiate(menuMusicPrefab);
			}
		}
	}
}