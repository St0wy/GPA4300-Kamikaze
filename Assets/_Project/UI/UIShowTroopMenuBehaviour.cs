using MyBox;
using UnityEngine;
using UnityEngine.UI;

namespace Kamikaze.UI
{
	public class UIShowTroopMenuBehaviour : MonoBehaviour
	{
		[SerializeField] private Button button;
		[SerializeField] private GameObject content;

		public SceneReference SceneToLoad { get; set; }
		
		public void ShowTroopMenu()
		{
			button.onClick.AddListener(StartGame);
			content.SetActive(true);
		}

		public void StartGame()
		{
			button.onClick.RemoveListener(StartGame);
			content.SetActive(false);
			SceneToLoad.LoadScene();
		}
	}
}