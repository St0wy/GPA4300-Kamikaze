using UnityEngine;

namespace Kamikaze.Units.Enemy
{
	[RequireComponent(typeof(HealthBehaviour), typeof(MoveOnLaneBehaviour))]
	public class EnemyTroopVarsSetterBehaviour : MonoBehaviour
	{
		[SerializeField] private EnemyTroopScriptableObject enemyTroopScriptableObject;

		private HealthBehaviour healthBehaviour;
		private MoveOnLaneBehaviour moveOnLaneBehaviour;

		private void Awake()
		{
			healthBehaviour = GetComponent<HealthBehaviour>();
			moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
			healthBehaviour.MaxHealthPoints = enemyTroopScriptableObject.HealthPoints;
			moveOnLaneBehaviour.MoveSpeed = enemyTroopScriptableObject.MoveSpeed;
		}
	}
}