using Kamikaze.Lanes.Selection;
using StowyTools.Logger;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kamikaze.Lanes
{
	public class ClickOnLanesManager : MonoBehaviour
	{
		public delegate void ClickEvent(Lane lane);

		public ClickEvent OnClick { get; set; }
		
		private void Update()
		{
			bool mouseClicked = Mouse.current.leftButton.wasPressedThisFrame;

			if (selectionManager == null || !mouseClicked) return;

			Transform currentSelection = selectionManager.CurrentSelection;

			if (currentSelection == null) return;
			
			var lane = currentSelection.GetComponent<Lane>();
			if (lane != null)
			{
				OnClick?.Invoke(lane);
			}
		}

		[SerializeField] private SelectionManager selectionManager;
	}
}