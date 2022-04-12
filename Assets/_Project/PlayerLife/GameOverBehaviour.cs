using Kamikaze.LevelSelect;
using Kamikaze.MonetarySystem;
using MyBox;
using UnityEngine;

namespace Kamikaze.PlayerLife
{
	public class GameOverBehaviour : MonoBehaviour
	{
		[SerializeField] private InventoryScriptableObject inventory;
		[SerializeField] private MoneyScriptableObject money;
		[SerializeField] private LifeManager lifeManager;
		[SerializeField] private GameObject gameOverMenu;
		[SerializeField] private SceneReference levelMenuScene;

		private int[] inventoryClone;
		private int moneyClone;

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
			moneyClone = money.Money;
		}

		public void LoadLevelMenu()
		{
			levelMenuScene.LoadScene();
		}

		public void QuitGame()
		{
			Application.Quit();
		}

		private void TriggerGameOver()
		{
			gameOverMenu.SetActive(true);
			inventory.UnitsAmount = inventoryClone;
			money.Money = moneyClone;
		}
	}
}