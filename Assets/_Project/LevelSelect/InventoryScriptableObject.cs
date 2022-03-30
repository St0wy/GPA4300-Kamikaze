using System;
using UnityEngine;

namespace Kamikaze.LevelSelect
{
	[CreateAssetMenu(fileName = "inventory", menuName = "Data/Inventory", order = 0)]
	public class InventoryScriptableObject : ScriptableObject
	{
		[SerializeField] private int[] unitsAmount;

		public int[] UnitsAmount
		{
			get => unitsAmount;
			set => unitsAmount = value;
		}
	}
}