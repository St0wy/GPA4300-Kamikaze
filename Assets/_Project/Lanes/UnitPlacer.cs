using Kamikaze.LevelSelect;
using Kamikaze.Units;
using Kamikaze.Units.Ally;
using Kamikaze.Units.Ally.Explosions;
using Kamikaze.Units.Ally.Shield;
using Kamikaze.Audio;
using UnityEngine;

namespace Kamikaze.Lanes
{
	[RequireComponent(typeof(ClickOnLanesManager))]
	public class UnitPlacer : MonoBehaviour
	{
		[SerializeField] private UnitSelector unitSelector;
		[SerializeField] private LanesManager lanesManager;
		[SerializeField] private ExplosionManager explosionManager;
		[SerializeField] private InventoryScriptableObject inventory;
		[SerializeField] private SoundEffectScriptableObject deployTroopSound;

		private ClickOnLanesManager clickOnLanesManager;

		private void Awake()
		{
			clickOnLanesManager = GetComponent<ClickOnLanesManager>();
			clickOnLanesManager.OnClick += PlaceUnit;
		}

		
		private void PlaceUnit(Lane lane, float pos)
		{
			int unitQuantity = inventory.UnitsAmount[unitSelector.SelectedUnitId];
			if (unitQuantity <= 0) return;

			bool isUnlocked = unitSelector.SelectedUnit.GetComponent<AllyTroopVarsSetterBehaviour>().
				AllyTroopScriptableObject.IsUnlocked;
			if (!isUnlocked) return;

			inventory.UnitsAmount[unitSelector.SelectedUnitId]--;
			InstantiateUnit(lane, pos);

		}

		private void InstantiateUnit(Lane lane, float pos)
		{
			deployTroopSound.Play();
			GameObject unitPrefab = unitSelector.SelectedUnit;
			GameObject unit = Instantiate(unitPrefab, lane.StartPos, Quaternion.identity);

			var laneUnitBehaviour = unit.GetComponent<LaneUnitBehaviour>();
			if (laneUnitBehaviour != null)
			{
				laneUnitBehaviour.LanesManager = lanesManager;
				laneUnitBehaviour.LaneId = lane.Id;
			}

			var explodeOnDeathBehaviour = unit.GetComponent<ExplodeOnDeathBehaviour>();
			if (explodeOnDeathBehaviour != null) explodeOnDeathBehaviour.ExplosionsManager = explosionManager;

			var backInInventoryBehaviour = unit.GetComponent<BackInInventoryBehaviour>();
			if (backInInventoryBehaviour != null)
			{
				backInInventoryBehaviour.UnitPlacer = this;
				backInInventoryBehaviour.UnitId = unitSelector.SelectedUnitId;
			}

			var shieldTroopBehavior = unit.GetComponent<ShieldTroopBehavior>();
			if (shieldTroopBehavior != null) shieldTroopBehavior.StopPosition = pos;
		}
	}
}