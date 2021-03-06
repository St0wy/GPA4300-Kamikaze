using JetBrains.Annotations;
using Kamikaze.Audio;
using Kamikaze.LevelSelect;
using Kamikaze.MonetarySystem;
using Kamikaze.Units.Ally;
using TMPro;
using UnityEngine;

namespace Kamikaze.UI
{
	public class UIBuyTroopBehaviour : MonoBehaviour
	{
		[SerializeField] private InventoryScriptableObject inventory;
		[SerializeField] private MoneyScriptableObject money;
		[SerializeField] private AllyTroopScriptableObject troop;
		[SerializeField] private TextMeshProUGUI textAmount;
		[SerializeField] private int troopId;
		[SerializeField] private SoundEffectScriptableObject clickSound;

		private void Start()
		{
			UpdateText();
		}

		[UsedImplicitly]
		public void BuyTroop()
		{
			if (money.Money < troop.Cost) return;

			clickSound.Play();
			money.Money -= troop.Cost;
			inventory.UnitsAmount[troopId]++;
			UpdateText();
		}

		[UsedImplicitly]
		public void SellTroop()
		{
			if (inventory.UnitsAmount[troopId] <= 0) return;

			clickSound.Play();
			money.Money += troop.Cost;
			inventory.UnitsAmount[troopId]--;
			UpdateText();
		}

		private void UpdateText()
		{
			textAmount.text = inventory.UnitsAmount[troopId].ToString();
		}
	}
}