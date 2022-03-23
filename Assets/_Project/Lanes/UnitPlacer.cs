using Kamikaze.Units;
using Kamikaze.Units.Ally.Explosions;
using Kamikaze.Units.Ally.Shield;
using UnityEngine;

namespace Kamikaze.Lanes
{
	[RequireComponent(typeof(ClickOnLanesManager))]
	public class UnitPlacer : MonoBehaviour
	{
		[SerializeField] private UnitSelector unitSelector;
		[SerializeField] private LanesManager lanesManager;
		[SerializeField] private ExplosionManager explosionManager;

		private ClickOnLanesManager clickOnLanesManager;
		[SerializeField] private int[] unitQuantities;

		private void Awake()
		{
			clickOnLanesManager = GetComponent<ClickOnLanesManager>();
			clickOnLanesManager.OnClick += PlaceUnit;
			// unitQuantities = new int[unitSelector.PrefabsLength];
		}

		private void PlaceUnit(Lane lane, float pos)
		{
			int unitQuantity = unitQuantities[unitSelector.SelectedUnitId];
			if (unitQuantity <= 0) return;
			unitQuantities[unitSelector.SelectedUnitId]--;
			InstantiateUnit(lane, pos);
		}

		private void InstantiateUnit(Lane lane, float pos)
		{
			GameObject unitPrefab = unitSelector.SelectedUnit;
			GameObject unit = Instantiate(unitPrefab, lane.StartPos, Quaternion.identity);

			var laneUnitBehaviour = unit.GetComponent<LaneUnitBehaviour>();
			if (laneUnitBehaviour != null)
			{
				laneUnitBehaviour.LanesManager = lanesManager;
				laneUnitBehaviour.LaneId = lane.Id;
			}

			var explodeOnDeathBehaviour = unit.GetComponent<ExplodeOnDeathBehaviour>();
			if (explodeOnDeathBehaviour != null)
			{
				explodeOnDeathBehaviour.ExplosionsManager = explosionManager;
			}

			var shieldTroopBehavior = unit.GetComponent<ShieldTroopBehavior>();
			if (shieldTroopBehavior != null)
			{
				shieldTroopBehavior.StopPosition = pos;
			}
		}
	}
}