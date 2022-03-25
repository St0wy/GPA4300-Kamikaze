using System;
using MyBox;
using UnityEngine;

namespace Kamikaze.Units.Enemy
{
	[RequireComponent(typeof(MoveOnLaneBehaviour))]
	public class DamageOnCollisionBehaviour : MonoBehaviour
	{
		[Tooltip("The tag that this object will damage.")] [Tag] [SerializeField]
		private string tagToDamage = string.Empty;

		[SerializeField] [ReadOnly] private EnemyState state = EnemyState.Walking;
		private float attackTimer;
		private MoveOnLaneBehaviour moveOnLaneBehaviour;
		private float oldSpeed;
		private HealthBehaviour target;

		public int Damage { get; set; }

		public float AttackSpeed { get; set; }

		public EnemyState State
		{
			get => state;
			set
			{
				state = value;
				switch (State)
				{
					case EnemyState.Walking:
						moveOnLaneBehaviour.MoveSpeed = oldSpeed;
						break;
					case EnemyState.Attacking:
						oldSpeed = moveOnLaneBehaviour.MoveSpeed;
						moveOnLaneBehaviour.MoveSpeed = 0f;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		private void Awake()
		{
			moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
			oldSpeed = moveOnLaneBehaviour.MoveSpeed;
		}

		private void Update()
		{
			if (State != EnemyState.Attacking) return;

			attackTimer -= Time.deltaTime;

			if (!(attackTimer <= 0)) return;

			target.ReduceHealth(Damage);
			attackTimer = AttackSpeed;

			if (target.IsAlive) return;

			State = EnemyState.Walking;
			attackTimer = 0;
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (!collision.gameObject.CompareTag(tagToDamage)) return;

			var healthBehaviour = collision.gameObject.GetComponent<HealthBehaviour>();
			if (healthBehaviour == null) return;

			State = EnemyState.Attacking;
			target = healthBehaviour;
		}
	}
}