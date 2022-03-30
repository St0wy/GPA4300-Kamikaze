using Kamikaze.LevelSelect;
using MyBox;
using UnityEngine;

namespace Kamikaze.PlayerLife
{
	public class GameOverBehaviour : MonoBehaviour
	{
		[SerializeField] private InventoryScriptableObject inventory;
		[SerializeField] private LifeManager lifeManager;
		[SerializeField] private GameObject gameOverMenu;
		[SerializeField] private SceneReference levelMenuScene;

		private int[] inventoryClone;

		private void Awake()
		{
			lifeManager.OnHurt += () =>
			{
				if (!lifeManager.IsAlive)
				{
					TriggerGameOver();
				}
			};
		}

		private void Start()
		{
			inventoryClone = inventory.UnitsAmount.Clone() as int[];
		}

		public void LoadLevelMenu()
		{
			levelMenuScene.LoadScene();
		}

		private void TriggerGameOver()
		{
			gameOverMenu.SetActive(true);
			inventory.UnitsAmount = inventoryClone;
		}
	}
}