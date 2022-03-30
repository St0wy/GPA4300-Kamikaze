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
			button.onClick.AddListener(ButtonClick);
			content.SetActive(true);
		}

		public void ButtonClick()
		{
			button.onClick.RemoveListener(ButtonClick);
			content.SetActive(false);
			SceneToLoad.LoadScene();
		}
	}
}