using MyBox;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Kamikaze.MonetarySystem
{
	[RequireComponent(typeof(ClickOnDropManager))]
	public class DropManager : MonoBehaviour
	{
		private ClickOnDropManager clickOnDropManager;

		[field: SerializeField, ReadOnly] public int DropQuantity { get; private set; }

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

		private void PickupDrop(Object drop)
		{
			DropQuantity++;
			Destroy(drop);
		}
	}
}