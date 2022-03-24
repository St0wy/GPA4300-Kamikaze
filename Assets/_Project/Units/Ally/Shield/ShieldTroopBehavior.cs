using System;
using MyBox;
using UnityEngine;

namespace Kamikaze.Units.Ally.Shield
{
	[RequireComponent(typeof(LaneUnitBehaviour))]
	[RequireComponent(typeof(MoveOnLaneBehaviour))]
	[RequireComponent(typeof(HealthBehaviour))]
	public class ShieldTroopBehavior : MonoBehaviour
	{
		[SerializeField] private GameObject shieldGo;
		[SerializeField] private int shieldHealthPoints = 5;
		[ReadOnly] [SerializeField] private float stopPosition;
		private HealthBehaviour healthBehaviour;
		private MoveOnLaneBehaviour moveOnLaneBehaviour;
		private ShieldState state = ShieldState.Walking;

		private LaneUnitBehaviour unitBehaviour;

		public float StopPosition
		{
			get => stopPosition;
			set => stopPosition = Mathf.Clamp01(value);
		}

		private bool PassedPosition
		{
			get
			{
				return moveOnLaneBehaviour.Direction switch
				{
					MoveDirection.Right => unitBehaviour.Position >= StopPosition,
					MoveDirection.Left => unitBehaviour.Position <= StopPosition,
					_ => throw new ArgumentOutOfRangeException(),
				};
			}
		}

		private void Awake()
		{
			unitBehaviour = GetComponent<LaneUnitBehaviour>();
			moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
			healthBehaviour = GetComponent<HealthBehaviour>();
		}

		private void Update()
		{
			if (!(state == ShieldState.Walking && PassedPosition)) return;

			state = ShieldState.Shielding;
			healthBehaviour.HealthPoints = shieldHealthPoints;
			moveOnLaneBehaviour.MoveSpeed = 0f;
			shieldGo.transform.localScale = new Vector3(0.2f, 0.9f, 0.9f);
		}

		public void BreakShield()
		{
			int damage = healthBehaviour.HealthPoints - 1;
			healthBehaviour.ReduceHealth(damage);
			shieldGo.SetActive(false);
		}
	}
}