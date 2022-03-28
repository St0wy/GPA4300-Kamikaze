using System;
using UnityEngine;
using UnityEngine.UI;

namespace Kamikaze.LevelSelect
{
	[RequireComponent(typeof(Image), typeof(Button))]
	public class LevelButton : MonoBehaviour
	{
		[SerializeField] private int levelId;
		[SerializeField] private LevelsManager levelsManager;

		private Image image;
		private Button button;
		private Level level;

		private void Awake()
		{
			image = GetComponent<Image>();
			button = GetComponent<Button>();
		}

		private void Start()
		{
			level = levelsManager.Levels[levelId];

			UpdateStatus();
		}

		public void LoadScene()
		{
			level.LevelScene.LoadScene();
		}

		private void UpdateStatus()
		{
			switch (level.LevelStatus)
			{
				case LevelStatus.Locked:
					image.color = levelsManager.LockedColor;
					button.interactable = false;
					break;
				case LevelStatus.Finished:
					image.color = levelsManager.FinishedColor;
					button.interactable = false;
					break;
				case LevelStatus.Playable:
					image.color = levelsManager.PlayableColor;
					button.interactable = true;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}