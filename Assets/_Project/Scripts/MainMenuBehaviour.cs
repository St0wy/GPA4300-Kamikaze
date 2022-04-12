using JetBrains.Annotations;
using Kamikaze.Audio;
using MyBox;
using UnityEngine;

namespace Kamikaze
{
	public class MainMenuBehaviour : MonoBehaviour
	{
		[SerializeField] private SceneReference startScene;
		[SerializeField] private SceneReference creditsScene;
		[SerializeField] private SoundEffectScriptableObject clickMenuSound;

		[UsedImplicitly]
		public void StartGame()
		{
			clickMenuSound.Play();
			startScene.LoadScene();
		}

		[UsedImplicitly]
		public void QuitGame()
		{
			clickMenuSound.Play();
			Application.Quit();
		}

		[UsedImplicitly]
		public void ShowCredits()
		{
			clickMenuSound.Play();
			creditsScene.LoadScene();
		}
	}
}