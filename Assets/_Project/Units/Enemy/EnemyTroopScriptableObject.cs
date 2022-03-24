using UnityEngine;

namespace Kamikaze.Units.Enemy
{
	[CreateAssetMenu(fileName = "enemyTroop", menuName = "Troops/Enemy", order = 0)]
	public class EnemyTroopScriptableObject : TroopScriptableObject
	{
		[Tooltip("The amount of gems that the enemy will drop when he dies.")] [SerializeField]
		private int dropAmount;

		public int DropAmount => dropAmount;
	}
}