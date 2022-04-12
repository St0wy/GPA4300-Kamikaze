using JetBrains.Annotations;
using Kamikaze.Audio;
using MyBox;
using UnityEngine;

namespace Kamikaze.UI
{
	public class UICreditsBehaviour : MonoBehaviour
	{
		[SerializeField] private SceneReference mainMenuScene;
		[SerializeField] private SoundEffectScriptableObject clickMenuSound;

		[UsedImplicitly]
		public void LoadMainMenuScene()
		{
			clickMenuSound.Play();
			mainMenuScene.LoadScene();
		}
	}
}