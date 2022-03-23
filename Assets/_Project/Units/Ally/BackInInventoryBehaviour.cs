using System;
using System.Security.Cryptography;
using Kamikaze.Lanes;
using UnityEngine;

namespace Kamikaze.Units.Ally
{
	[RequireComponent(typeof(LaneUnitBehaviour))]
	public class BackInInventoryBehaviour : MonoBehaviour
	{
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

		private void ReturnInInventory()
		{
			UnitPlacer.UnitQuantities[UnitId] += 1;
			Destroy(gameObject);
		}
	}
}