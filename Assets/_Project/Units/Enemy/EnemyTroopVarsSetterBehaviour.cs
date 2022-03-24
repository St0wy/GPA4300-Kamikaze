using UnityEngine;

namespace Kamikaze.Units.Enemy
{
	[RequireComponent(typeof(MoveOnLaneBehaviour))]
	[RequireComponent(typeof(HealthBehaviour))]
	[RequireComponent(typeof(DropOnDeathBehaviour))]
	public class EnemyTroopVarsSetterBehaviour : MonoBehaviour
	{
		[SerializeField] private EnemyTroopScriptableObject enemyTroopScriptableObject;

		private HealthBehaviour healthBehaviour;
		private MoveOnLaneBehaviour moveOnLaneBehaviour;
		private DropOnDeathBehaviour dropOnDeathBehaviour;

		private void Awake()
		{
			healthBehaviour = GetComponent<HealthBehaviour>();
			moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
			dropOnDeathBehaviour = GetComponent<DropOnDeathBehaviour>();
			
			healthBehaviour.MaxHealthPoints = enemyTroopScriptableObject.HealthPoints;
			moveOnLaneBehaviour.MoveSpeed = enemyTroopScriptableObject.MoveSpeed;
			dropOnDeathBehaviour.DropAmount = enemyTroopScriptableObject.DropAmount;
		}
	}
}