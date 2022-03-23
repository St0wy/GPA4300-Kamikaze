using Kamikaze.Lanes;
using TMPro;
using UnityEngine;

namespace Kamikaze.UI
{
	public class UITroopQuantityManager : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI[] texts;
		[SerializeField] private UnitPlacer unitPlacer;

		private void Update()
		{
			for (var i = 0; i < texts.Length; i++)
			{
				TextMeshProUGUI text = texts[i];
				int unitQuantity = unitPlacer.UnitQuantities[i];
				text.text = unitQuantity.ToString();
			}
		}
	}
}