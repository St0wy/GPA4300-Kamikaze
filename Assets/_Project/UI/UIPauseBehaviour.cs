﻿using JetBrains.Annotations;
using Kamikaze.Audio.Music.MenuMusic;
using MyBox;
using UnityEngine;

namespace Kamikaze.UI
{
	public class UIPauseBehaviour : MonoBehaviour
	{
		[SerializeField] private GameObject content;
		[SerializeField] private SceneReference mainMenuScene;

		public bool IsPaused { get; private set; }

		[UsedImplicitly]
		public void Resume()
		{
			IsPaused = false;
			content.SetActive(false);
			Time.timeScale = 1f;
		}

		[UsedImplicitly]
		public void Pause()
		{
			IsPaused = true;
			content.SetActive(true);
			Time.timeScale = 0f;
		}

		[UsedImplicitly]
		public void LoadMainMenu()
		{
			Resume();
			var musicManager = FindObjectOfType<MenuMusicManager>();
			if (musicManager != null)
			{
				musicManager.PlayMusic();
			}

			mainMenuScene.LoadScene();
		}

		[UsedImplicitly]
		public void QuitGame()
		{
			Application.Quit();
		}
	}
}