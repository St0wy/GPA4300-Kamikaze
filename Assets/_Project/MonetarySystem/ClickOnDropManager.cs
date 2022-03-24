using Kamikaze.Lanes.Selection;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kamikaze.MonetarySystem
{
	public class ClickOnDropManager : MonoBehaviour
	{
		public delegate void ClickEvent(GameObject drop);

		[SerializeField] private SelectionManager selectionManager;

		public ClickEvent OnClick { get; set; }

		private void Update()
		{
			bool mouseClicked = Mouse.current.leftButton.wasPressedThisFrame;
			if (selectionManager == null || !mouseClicked) return;
			
			Transform currentSelection = selectionManager.CurrentSelection;
			if (currentSelection == null) return;
			
			OnClick?.Invoke(currentSelection.gameObject);
		}
	}
}