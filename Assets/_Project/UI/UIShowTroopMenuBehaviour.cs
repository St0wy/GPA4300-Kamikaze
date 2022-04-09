using Kamikaze.Audio;
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
			SceneToLoad.LoadScene();
		}

		public void LoadContent()
		{
			content.SetActive(true);

			foreach (UIShowTroopPanelBehaviour panel in panelsInContent) panel.ShowPanel();
		}
	}
}