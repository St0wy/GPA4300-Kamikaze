using JetBrains.Annotations;
using MyBox;
using UnityEngine;

namespace Kamikaze
{
	public class MainMenuBehaviour : MonoBehaviour
	{
		[SerializeField] private SceneReference startScene;

		[UsedImplicitly]
		public void StartGame()
		{
			startScene.LoadScene();
		}

		[UsedImplicitly]
		public void QuitGame()
		{
			Application.Quit();
		}
	}
}