using UnityEngine;

namespace Kamikaze.Lanes.Selection
{
	public class SelectionManager : MonoBehaviour
	{
		private IRayProvider rayProvider;
		private ISelectionResponse selectionResponse;
		private ISelector selector;

		public Transform CurrentSelection { get; private set; }
		public Vector3 CurrentPoint { get; private set; }

		private void Awake()
		{
			rayProvider = GetComponent<IRayProvider>();
			selector = GetComponent<ISelector>();
			selectionResponse = GetComponent<ISelectionResponse>();
		}

		private void Update()
		{
			if (CurrentSelection != null)
				selectionResponse.OnDeselect(CurrentSelection);

			selector.Check(rayProvider.CreateRay());
			CurrentSelection = selector.Selection;
			CurrentPoint = selector.Point;

			if (CurrentSelection != null)
				selectionResponse.OnSelect(CurrentSelection);
		}
	}
}