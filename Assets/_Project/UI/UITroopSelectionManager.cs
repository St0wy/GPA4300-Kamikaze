using Kamikaze.Lanes;
using UnityEngine;

namespace Kamikaze.UI
{
	public class UITroopSelectionManager : MonoBehaviour
	{
		[SerializeField] private UnitSelector unitSelector;
		[SerializeField] private UISelectionButtonBehaviour[] buttons;


		public void OnClick(UISelectionButtonBehaviour selectionButtonBehaviour)
		{
			unitSelector.SelectedUnitId = selectionButtonBehaviour.UnitId;

			foreach (UISelectionButtonBehaviour button in buttons)
				button.IsSelected = button.UnitId == selectionButtonBehaviour.UnitId;
		}
	}
}