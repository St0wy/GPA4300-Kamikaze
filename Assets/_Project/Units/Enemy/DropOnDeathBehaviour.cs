using Kamikaze.MonetarySystem;
using UnityEngine;

namespace Kamikaze.Units.Enemy
{
	[RequireComponent(typeof(HealthBehaviour))]
	public class DropOnDeathBehaviour : MonoBehaviour
	{
		[SerializeField] private GameObject dropPrefab;

		private HealthBehaviour healthBehaviour;
		
		public int DropAmount { get; set; }

		private void Awake()
		{
			healthBehaviour = GetComponent<HealthBehaviour>();
			healthBehaviour.OnHurt += OnHurt;
		}

		private void OnHurt(int healthPoints)
		{
			if (!healthBehaviour.IsAlive)
			{
				DropItem();
			}
		}

		private void DropItem()
		{
			GameObject item = Instantiate(dropPrefab, transform.position, Quaternion.identity);
			var dropBehaviour = item.GetComponent<DropBehaviour>();
			dropBehaviour.DropAmount = DropAmount;
		}
	}
}