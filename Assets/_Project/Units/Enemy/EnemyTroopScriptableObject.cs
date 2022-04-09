using UnityEngine;

namespace Kamikaze.Units.Enemy
{
	[CreateAssetMenu(fileName = "enemyTroop", menuName = "Troops/Enemy", order = 0)]
	public class EnemyTroopScriptableObject : TroopScriptableObject
	{
		[Tooltip("The amount of gems that the enemy will drop when he dies.")] [SerializeField]
		private int dropAmount;

		[Tooltip("The amount of damage that the unit will inflict everytime they attack.")] [SerializeField]
		private int damage;

		[Tooltip("The number of attacks per second.")] [SerializeField]
		private float attackSpeed;


		public int DropAmount => dropAmount;
		public int Damage => damage;
		public float AttackSpeed => attackSpeed;
	}
}