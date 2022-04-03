using MyBox;
using UnityEngine;
using UnityEngine.UI;
using Kamikaze.UnlockSystem;

namespace Kamikaze.UI
{
	public class UIShowTroopMenuBehaviour : MonoBehaviour
	{
		[SerializeField] private Button button;
		[SerializeField] private GameObject content;
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
			button.onClick.RemoveListener(StartGame);
			content.SetActive(false);
			SceneToLoad.LoadScene();
		}

		public void LoadContent()
        {
			content.SetActive(true);

			foreach (var panel in panelsInContent)
            {
				panel.ShowPanel();
            }
		}

	

	}
}