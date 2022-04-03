using UnityEngine;

namespace Kamikaze.Units.Ally.Rifle
{
	public class RifleAndShieldContactBehavior : MonoBehaviour
	{
		private MoveOnLaneBehaviour moveOnLaneBehaviour;
		private float initialSpeed;

		public bool RifleStayBehind { get; set; }

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
			moveOnLaneBehaviour.MoveSpeed = RifleStayBehind ? 0f : initialSpeed;
		}
	}
}