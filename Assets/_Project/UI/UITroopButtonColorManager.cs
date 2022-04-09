using Kamikaze.LevelSelect;
using UnityEngine;
using UnityEngine.UI;

namespace Kamikaze.UI
{
	public class UITroopButtonColorManager : MonoBehaviour
	{
		[SerializeField] private InventoryScriptableObject inventory;
		[SerializeField] private int unitID;
		private Button button;

		private void Awake()
		{
			button = GetComponent<Button>();
		}

		private void Update()
		{
			button.interactable = inventory.UnitsAmount[unitID] > 0;
		}
	}
}