using MyBox;
using UnityEngine;

namespace Kamikaze.MonetarySystem
{
	[RequireComponent(typeof(ClickOnDropManager))]
	public class DropManager : MonoBehaviour
	{
		[SerializeField] private MoneyScriptableObject moneyScriptableObject;

		[field: SerializeField, ReadOnly] public int DropQuantity { get; private set; }

		private ClickOnDropManager clickOnDropManager;

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