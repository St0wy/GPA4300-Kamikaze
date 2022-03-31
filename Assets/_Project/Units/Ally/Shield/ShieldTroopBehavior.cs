using System;
using MyBox;
using UnityEngine;
using Kamikaze.Units.Ally.Rifle;

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
		private LaneUnitBehaviour unitBehaviour;

		#region Properties

		public ShieldState State { get; set; } = ShieldState.Walking;

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

		public RifleAndShieldContactBehavior RifleAndShieldContactBehavior { get; set; }

		#endregion

		private void Awake()
		{
			unitBehaviour = GetComponent<LaneUnitBehaviour>();
			moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
			healthBehaviour = GetComponent<HealthBehaviour>();

			healthBehaviour.OnHurt += VerifyAbilityToProtectRifle;
		}

		private void Update()
		{
			if (!(State == ShieldState.Walking && PassedPosition)) return;

			State = ShieldState.Shielding;
			healthBehaviour.HealthPoints = shieldHealthPoints;
			moveOnLaneBehaviour.MoveSpeed = 0f;
			shieldGo.transform.localScale = new Vector3(2f, 2f, 2f);
		}

		public void BreakShield()
		{
			int damage = healthBehaviour.HealthPoints - 1;
			healthBehaviour.ReduceHealth(damage);
			shieldGo.SetActive(false);
		}

		private void VerifyAbilityToProtectRifle(int healthPoints)
		{
			if (healthPoints <= 0 && RifleAndShieldContactBehavior != null)
			{
				RifleAndShieldContactBehavior.RifleStayBehind = false;
			}
		}
	}
}