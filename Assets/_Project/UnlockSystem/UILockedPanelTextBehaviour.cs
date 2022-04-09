using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kamikaze.UnlockSystem
{
	public class UILockedPanelTextBehaviour : MonoBehaviour
	{
		[FormerlySerializedAs("uIShowTroopBehaviour")] [SerializeField]
		private UIShowTroopPanelBehaviour showTroopBehaviour;

		[SerializeField] private TextMeshProUGUI textMeshProUGUI;

		private void Start()
		{
			DisplayMenuLockPanelText();
		}

		private void DisplayMenuLockPanelText()
		{
			textMeshProUGUI.text =
				$"Finish{Environment.NewLine}level {showTroopBehaviour.LevelToReach - 1}{Environment.NewLine}" +
				$"to unlock{Environment.NewLine}troop";
		}
	}
}