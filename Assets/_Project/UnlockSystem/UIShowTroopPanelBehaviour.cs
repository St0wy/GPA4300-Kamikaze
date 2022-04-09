using Kamikaze.LevelSelect;
using UnityEngine;

namespace Kamikaze.UnlockSystem
{
	public class UIShowTroopPanelBehaviour : MonoBehaviour
	{
		[SerializeField] private LevelsManagerScriptableObject levelsManagerScriptableObject;
		[SerializeField] private int levelToReach;
		[SerializeField] private GameObject troopPanelUnlock;
		[SerializeField] private GameObject troopPanelLock;

		public bool CanUnlockPanel { get; set; }
		public int LevelToReach => levelToReach;

		public void ShowPanel()
		{
			if (levelsManagerScriptableObject.CurrentLevelId + 1 >= levelToReach) CanUnlockPanel = true;

			troopPanelUnlock.SetActive(CanUnlockPanel);
			troopPanelLock.SetActive(!CanUnlockPanel);
		}
	}
}