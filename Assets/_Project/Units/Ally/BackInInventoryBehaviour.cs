using Kamikaze.Lanes;
using Kamikaze.LevelSelect;
using UnityEngine;

namespace Kamikaze.Units.Ally
{
	[RequireComponent(typeof(LaneUnitBehaviour))]
	public class BackInInventoryBehaviour : MonoBehaviour
	{
		[SerializeField] private InventoryScriptableObject inventory;
		
		private LaneUnitBehaviour laneUnitBehaviour;

		public UnitPlacer UnitPlacer { get; set; }
		public int UnitId { get; set; }

		private void Awake()
		{
			laneUnitBehaviour = GetComponent<LaneUnitBehaviour>();
		}

		private void Update()
		{
			if (!(laneUnitBehaviour.Position >= 1)) return;

			ReturnInInventory();
		}

		public void ReturnInInventory()
		{
			inventory.UnitsAmount[UnitId] += 1;
			Destroy(gameObject);
		}
	}
}