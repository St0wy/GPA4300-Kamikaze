using Kamikaze.Audio;
using Kamikaze.Audio.Music.MenuMusic;
using Kamikaze.UnlockSystem;
using MyBox;
using UnityEngine;
using UnityEngine.UI;

namespace Kamikaze.UI
{
	public class UIShowTroopMenuBehaviour : MonoBehaviour
	{
		[SerializeField] private Button button;
		[SerializeField] private GameObject content;
		[SerializeField] private SoundEffectScriptableObject clickMenuSound;
		private UIShowTroopPanelBehaviour[] panelsInContent;

		public SceneReference SceneToLoad { get; set; }

		private void Awake()
		{
			panelsInContent = content.GetComponentsInChildren<UIShowTroopPanelBehaviour>();
		}

		public void ShowTroopMenu()
		{
			button.onClick.AddListener(StartGame);
			LoadContent();
		}

		public void StartGame()
		{
			clickMenuSound.Play();

			button.onClick.RemoveListener(StartGame);
			content.SetActive(false);

			var musicManager = FindObjectOfType<MenuMusicManager>();
			if (musicManager != null)
			{
				musicManager.StopMusic();
			}

			SceneToLoad.LoadScene();
		}

		public void LoadContent()
		{
			content.SetActive(true);

			panelsInContent.ForEach(panel => panel.ShowPanel());
		}

		public void HidePanel()
		{
			content.SetActive(false);
		}
	}
}