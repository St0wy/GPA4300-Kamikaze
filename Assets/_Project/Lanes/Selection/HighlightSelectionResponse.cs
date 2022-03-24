using UnityEngine;

namespace Kamikaze.Lanes.Selection
{
	public class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
	{
		[SerializeField] private Material highlightMaterial;
		
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
			selectionRenderer.material = highlightMaterial;
		}
	}
}