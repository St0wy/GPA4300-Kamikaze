using System;
using JetBrains.Annotations;
using Kamikaze.Audio.Music.MenuMusic;
using Kamikaze.PlayerLife;
using MyBox;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kamikaze.UI
{
	public class UIPauseBehaviour : MonoBehaviour
	{
		[SerializeField] private GameObject content;
		[SerializeField] private SceneReference mainMenuScene;
		[SerializeField] private GameOverBehaviour gameOverBehaviour;

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

			// Play main menu music
			var musicManager = FindObjectOfType<MenuMusicManager>();
			if (musicManager != null)
			{
				musicManager.PlayMusic();
			}

			// Reset money and inventory
			gameOverBehaviour.ResetValues();

			mainMenuScene.LoadScene();
		}

		[UsedImplicitly]
		public void QuitGame()
		{
			Application.Quit();
		}

		[UsedImplicitly]
		public void RestartLevel()
		{
			Resume();
			gameOverBehaviour.ResetValues();
			Scene currentScene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(currentScene.name);
		}
	}
}