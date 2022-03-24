using MyBox;
using StowyTools.Logger;
using UnityEngine;

namespace Kamikaze.MonetarySystem
{
	[RequireComponent(typeof(ClickOnDropManager))]
	public class DropManager : MonoBehaviour
	{
		private ClickOnDropManager clickOnDropManager;

		[field: SerializeField]
		[field: ReadOnly]
		public int DropQuantity { get; private set; }

		private void Awake()
		{
			clickOnDropManager = GetComponent<ClickOnDropManager>();
			clickOnDropManager.OnClick += OnClick;
		}

		private void OnClick(GameObject drop)
		{
			var dropBehaviour = drop.GetComponent<DropBehaviour>();
			if (dropBehaviour == null) return;

			PickupDrop(drop);
		}

		private void PickupDrop(GameObject drop)
		{
			this.Log(drop);
			var dropBehaviour = drop.GetComponent<DropBehaviour>();
			if (dropBehaviour == null) return;

			DropQuantity += dropBehaviour.DropAmount;
			Destroy(drop);
		}
	}
}