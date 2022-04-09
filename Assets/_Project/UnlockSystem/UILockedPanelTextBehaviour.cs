using System;
using UnityEngine;
using TMPro;

namespace Kamikaze.UnlockSystem
{
	public class UILockedPanelTextBehaviour : MonoBehaviour
	{
		[SerializeField] private UIShowTroopPanelBehaviour uIShowTroopBehaviour;
		[SerializeField] private TextMeshProUGUI textMeshProUGUI;

		private void Start()
		{
			DisplayMenuLockPanelText();
		}

		private void DisplayMenuLockPanelText()
		{
			textMeshProUGUI.text =
				$"Finish{Environment.NewLine}level {uIShowTroopBehaviour.LevelToReach-1}{Environment.NewLine}" +
				$"to unlock{Environment.NewLine}troop";
		}
	}
}