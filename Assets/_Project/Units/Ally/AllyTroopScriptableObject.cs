using UnityEngine;

namespace Kamikaze.Units.Ally
{
	[CreateAssetMenu(fileName = "allyTroop", menuName = "Troops/Ally", order = 0)]
	public class AllyTroopScriptableObject : TroopScriptableObject
	{
		[Tooltip("Price of the troop in $.")] [SerializeField]
		private int cost;

		[Tooltip("Tell if the troop is unlocked")][SerializeField]
		private bool isUnlocked;

		public int Cost => cost;

		public bool IsUnlocked 
		{ 
			get => isUnlocked; 
			set => isUnlocked = value;
		}
	}
}