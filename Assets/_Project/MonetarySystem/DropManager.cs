using MyBox;
using UnityEngine;

namespace Kamikaze.MonetarySystem
{
	[RequireComponent(typeof(HoverOnDropManager))]
	public class DropManager : MonoBehaviour
	{
		[field: SerializeField, ReadOnly] public int DropQuantity { get; private set; }

		private HoverOnDropManager hoverOnDropManager;

		private void Awake()
		{
			hoverOnDropManager = GetComponent<HoverOnDropManager>();
			hoverOnDropManager.OnClick += OnClick;
		}

		private void OnClick(GameObject drop)
		{
			var dropBehaviour = drop.GetComponent<DropBehaviour>();
			if (dropBehaviour == null) return;

			PickupDrop(drop);
		}

		private void PickupDrop(GameObject drop)
		{
			var dropBehaviour = drop.GetComponent<DropBehaviour>();
			if (dropBehaviour == null) return;

			PickupGem(dropBehaviour);
		}

		public void PickupGem(DropBehaviour gem)
		{
			DropQuantity += gem.DropAmount;
			Destroy(gem.gameObject);
		}
	}
}