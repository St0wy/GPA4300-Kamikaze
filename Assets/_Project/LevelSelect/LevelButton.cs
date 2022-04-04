using System;
using Kamikaze.UI;
using UnityEngine;
using UnityEngine.UI;
using Kamikaze.Audio;

namespace Kamikaze.LevelSelect
{
	[RequireComponent(typeof(Image), typeof(Button))]
	public class LevelButton : MonoBehaviour
	{
		[SerializeField] private int levelId;
		[SerializeField] private LevelsManagerScriptableObject levelsManagerScriptableObject;
		[SerializeField] private UIShowTroopMenuBehaviour showTroopMenuBehaviour;
		[SerializeField] private SoundEffectScriptableObject clickMenuSound;

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
			level = levelsManagerScriptableObject.Levels[levelId];

			UpdateStatus();
		}

		public void LoadScene()
		{
			clickMenuSound.Play();
			showTroopMenuBehaviour.SceneToLoad = level.LevelScene;
			showTroopMenuBehaviour.ShowTroopMenu();
		}

		private void UpdateStatus()
		{
			switch (level.LevelStatus)
			{
				case LevelStatus.Locked:
					image.color = levelsManagerScriptableObject.LockedColor;
					button.interactable = false;
					break;
				case LevelStatus.Finished:
					image.color = levelsManagerScriptableObject.FinishedColor;
					button.interactable = false;
					break;
				case LevelStatus.Playable:
					image.color = levelsManagerScriptableObject.PlayableColor;
					button.interactable = true;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}