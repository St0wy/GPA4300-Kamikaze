using MyBox;
using UnityEngine;
using Kamikaze.Audio;

namespace Kamikaze.MonetarySystem
{
	[RequireComponent(typeof(HoverOnDropManager))]
	public class DropManager : MonoBehaviour
	{
		[field: SerializeField, ReadOnly] public int DropQuantity { get; private set; }

		private HoverOnDropManager hoverOnDropManager;
		[SerializeField] private SoundEffectScriptableObject recoltSound;

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
			recoltSound.Play();
			DropQuantity += gem.DropAmount;
			Destroy(gem.gameObject);
		}
	}
}