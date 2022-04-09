using UnityEngine;

namespace Kamikaze.Units.Ally.Rifle
{
	public class RifleAndShieldContactBehavior : MonoBehaviour
	{
		private float initialSpeed;
		private MoveOnLaneBehaviour moveOnLaneBehaviour;

		public bool BlockRifle { get; set; }

		private void Awake()
		{
			moveOnLaneBehaviour = transform.GetComponent<MoveOnLaneBehaviour>();
		}

		private void Start()
		{
			initialSpeed = moveOnLaneBehaviour.MoveSpeed;
		}

		private void Update()
		{
			moveOnLaneBehaviour.MoveSpeed = BlockRifle ? 0f : initialSpeed;
		}
	}
}