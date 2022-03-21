﻿using System;
using Kamikaze.Units;
using Kamikaze.Units.Ally.Explosions;
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

		private void PlaceUnit(Lane lane)
		{
			int unitQuantity = unitQuantities[unitSelector.SelectedUnitId];
			if (unitQuantity <= 0) return;
			unitQuantities[unitSelector.SelectedUnitId]--;
			InstantiateUnit(lane);
		}

		private void InstantiateUnit(Lane lane)
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
		}
	}
}