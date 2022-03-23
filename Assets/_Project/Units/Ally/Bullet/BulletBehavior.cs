using UnityEngine;

namespace Kamikaze.Units.Ally.Bullet
{
	public class BulletBehavior : MonoBehaviour
	{
		[SerializeField] private float normalSpeed = 80f;

		private Rigidbody rb;

		public float Speed { get; set; }

		public Vector3 Movement { get; set; }

		public float NormalSpeed => normalSpeed;

		private void Start()
		{
			rb = GetComponent<Rigidbody>();

			Movement.Normalize();

			Speed = NormalSpeed;
		}

		private void FixedUpdate()
		{
			rb.velocity = Movement * Speed;
		}
	}
}