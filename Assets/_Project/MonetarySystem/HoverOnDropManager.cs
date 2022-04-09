using Kamikaze.Lanes.Selection;
using UnityEngine;

namespace Kamikaze.MonetarySystem
{
	public class HoverOnDropManager : MonoBehaviour
	{
		public delegate void ClickEvent(GameObject drop);

		[SerializeField] private SelectionManager selectionManager;

		public ClickEvent OnClick { get; set; }

		private void Update()
		{
			if (selectionManager == null) return;

			Transform currentSelection = selectionManager.CurrentSelection;
			if (currentSelection == null) return;

			var dropBehaviour = currentSelection.GetComponent<DropBehaviour>();
			if (dropBehaviour == null) return;


			OnClick?.Invoke(currentSelection.gameObject);
		}
	}
}