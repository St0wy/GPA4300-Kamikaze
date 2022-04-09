using Kamikaze.Audio;
using MyBox;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kamikaze.MonetarySystem
{
	[RequireComponent(typeof(HoverOnDropManager))]
	public class DropManager : MonoBehaviour
	{
		[FormerlySerializedAs("recoltSound")] [SerializeField]
		private SoundEffectScriptableObject pickupSound;

		private HoverOnDropManager hoverOnDropManager;

		[field: SerializeField]
		[field: ReadOnly]
		public int DropQuantity { get; private set; }

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
			pickupSound.Play();
			DropQuantity += gem.DropAmount;
			Destroy(gem.gameObject);
		}
	}
}