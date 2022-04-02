using MyBox;
using UnityEngine;
using UnityEngine.UI;

namespace Kamikaze.UI
{
	public class UIShowTroopMenuBehaviour : MonoBehaviour
	{
		[SerializeField] private Button button;
		[SerializeField] private GameObject content;
		private UIShowTroopBehaviour[] panelsInContent;

		public SceneReference SceneToLoad { get; set; }

        private void Awake()
        {
			panelsInContent = content.GetComponentsInChildren<UIShowTroopBehaviour>();
        }

        public void ShowTroopMenu()
		{
			button.onClick.AddListener(StartGame);
			content.SetActive(true);
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
			foreach(var panel in panelsInContent)
            {
				if(panel.IsUnlocked)
                {
					panel.ShowUnlockedPanel();
					panel.HideLockedPanel();
                }

                else
                {
					panel.ShowLockedPanel();
					panel.HideUnlockedPanel();
				}
            }
		}

	

	}
}