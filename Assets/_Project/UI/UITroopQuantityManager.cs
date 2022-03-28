using Kamikaze.LevelSelect;
using TMPro;
using UnityEngine;

namespace Kamikaze.UI
{
	public class UITroopQuantityManager : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI[] texts;
		[SerializeField] private InventoryScriptableObject inventory;

		private void Update()
		{
			for (var i = 0; i < texts.Length; i++)
			{
				TextMeshProUGUI text = texts[i];
				int unitQuantity = inventory.UnitsAmount[i];
				text.text = unitQuantity.ToString();
			}
		}
	}
}