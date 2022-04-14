using Kamikaze.Screenshake;
using MyBox;
using UnityEngine;

namespace Kamikaze.Units.Ally.Explosions
{
	/// <summary>
	/// Behaviour to put on objects that should explode on death.
	/// </summary>
	[RequireComponent(typeof(HealthBehaviour))]
	public class ExplodeOnDeathBehaviour : MonoBehaviour
	{
		[SerializeField] private ExplosionScriptableObject explosionScriptableObject;

		private HealthBehaviour healthBehaviour;

		public ExplosionEvent ExplosionEvent { get; set; }

		[field: SerializeField] public ExplosionManager ExplosionsManager { get; set; }

		private void Awake()
		{
			healthBehaviour = GetComponent<HealthBehaviour>();
			healthBehaviour.OnHurt += OnHurt;
		}

		private void OnDrawGizmosSelected()
		{
			Vector3 position = transform.position;
			Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
			Gizmos.DrawSphere(position, explosionScriptableObject.ExplosionRadius);
			Gizmos.color = new Color(0f, 0f, 1f, 0.1f);
			Gizmos.DrawSphere(position, explosionScriptableObject.MaxDamageMargin);
		}

		private void OnDestroy()
		{
			healthBehaviour.OnHurt -= OnHurt;
		}

		private void OnHurt(int healthPoints)
		{
			if (!healthBehaviour.IsAlive) Explode();
		}

		[ButtonMethod]
		private void Explode()
		{
			ExplosionsManager.TriggerExplosion(transform.position, explosionScriptableObject, ExplosionEvent);
			float screenShakePower = explosionScriptableObject.ScreenShakePower;
			float screeShakeDuration = explosionScriptableObject.ScreenShakeDuration;
			ScreenshakeController.Instance.StartScreenShake(screenShakePower, screeShakeDuration);
			if (explosionScriptableObject != null) explosionScriptableObject.ExplosionSound.Play();
		}
	}
}