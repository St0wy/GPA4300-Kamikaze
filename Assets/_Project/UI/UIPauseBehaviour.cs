using JetBrains.Annotations;
using MyBox;
using UnityEngine;

namespace Kamikaze.UI
{
	public class UIPauseBehaviour : MonoBehaviour
	{
		[SerializeField] private GameObject content;
		[SerializeField] private SceneReference mainMenuScene;

		public bool IsPaused { get; private set; } = false;

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
			mainMenuScene.LoadScene();
		}

		[UsedImplicitly]
		public void QuitGame()
		{
			Application.Quit();
		}
	}
}