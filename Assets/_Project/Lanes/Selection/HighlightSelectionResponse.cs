using Kamikaze.LevelSelect;
using UnityEngine;

namespace Kamikaze.Lanes.Selection
{
	public class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
	{
		[SerializeField] private Material highlightMaterialUnitAvailable;
		[SerializeField] private Material highlightMaterialNoUnit;
		[SerializeField] private UnitSelector unitSelector;
		[SerializeField] private InventoryScriptableObject inventory;

		private Material defaultMaterial;

		public void OnDeselect(Transform selection)
		{
			var selectionRenderer = selection.GetComponent<Renderer>();
			if (selectionRenderer != null) selectionRenderer.material = defaultMaterial;
		}

		public void OnSelect(Transform selection)
		{
			var selectionRenderer = selection.GetComponent<Renderer>();
			if (selectionRenderer == null) return;

			defaultMaterial = selectionRenderer.material;
			selectionRenderer.material = inventory.UnitsAmount[unitSelector.SelectedUnitId] <= 0
				? highlightMaterialNoUnit
				: highlightMaterialUnitAvailable;
		}
	}
}