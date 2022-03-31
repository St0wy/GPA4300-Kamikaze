using Kamikaze.Lanes.Selection;
using Kamikaze.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kamikaze.Lanes
{
	public class ClickOnLanesManager : MonoBehaviour
	{
		public delegate void ClickEvent(Lane lane, float position);

		[SerializeField] private SelectionManager selectionManager;
		[SerializeField] private UIPauseBehaviour pause;

		public ClickEvent OnClick { get; set; }

		private void Update()
		{
			bool mouseClicked = Mouse.current.leftButton.wasPressedThisFrame;
			bool clickedSelected = selectionManager == null || !mouseClicked || pause.IsPaused;
			if (clickedSelected) return;

			Transform currentSelection = selectionManager.CurrentSelection;

			if (currentSelection == null) return;

			var lane = currentSelection.GetComponent<Lane>();

			if (lane == null) return;

			Vector3 point = selectionManager.CurrentPoint;
			OnClick?.Invoke(lane, lane.GetLanePositionFromWorld(point));
		}
	}
}