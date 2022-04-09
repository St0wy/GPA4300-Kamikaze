using Kamikaze.LevelSelect;
using Kamikaze.Units.Ally;
using UnityEngine;

namespace Kamikaze.UnlockSystem
{
	public class UIShowTroopButtonBehaviour : MonoBehaviour
	{
		[SerializeField] private LevelsManagerScriptableObject levelsManagerScriptableObject;
		[SerializeField] private AllyTroopScriptableObject troopData;
		[SerializeField] private int levelToReach;
		[SerializeField] private GameObject lockPrefab;
		[SerializeField] private GameObject troopNameGo;
		[SerializeField] private GameObject quantityGo;

		public int LevelToReach => levelToReach;

		private void Start()
		{
			if (levelsManagerScriptableObject.CurrentLevelId + 1 >= levelToReach) troopData.IsUnlocked = true;

			ShowButton();
		}

		private void Update()
		{
			ShowButton();
		}

		public void ShowButton()
		{
			ShowLockState();
		}

		public void ShowLockState()
		{
			lockPrefab.SetActive(!troopData.IsUnlocked);
			troopNameGo.SetActive(troopData.IsUnlocked);
			quantityGo.SetActive(troopData.IsUnlocked);
		}
	}
}