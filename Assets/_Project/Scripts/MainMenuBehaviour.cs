using JetBrains.Annotations;
using MyBox;
using UnityEngine;
using Kamikaze.Audio;

namespace Kamikaze
{
	public class MainMenuBehaviour : MonoBehaviour
	{
		[SerializeField] private SceneReference startScene;
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
	}
}