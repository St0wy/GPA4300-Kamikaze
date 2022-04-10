using Kamikaze.LevelSelect;
using MyBox;
using UnityEngine;

namespace Kamikaze
{
	public class EndGameManager : MonoBehaviour
	{
		[SerializeField] private LevelsManagerScriptableObject levelsManager;
		[SerializeField] private SceneReference endScene;

		private void Start()
		{
			if (levelsManager.AreAllLevelsFinished)
			{
				endScene.LoadScene();
			}
		}
	}
}