using UnityEngine;

namespace Kamikaze.Units.Ally.Rifle
{
	public class RifleTroopBehavior : MonoBehaviour
	{
		[SerializeField] private float timeBetweenShoots = 0.2f;
		[SerializeField] private float timeUntilNextShoot;
		private HealthBehaviour healthBehaviour;

		private Rifle rifle;

		private void Awake()
		{
			timeUntilNextShoot = timeBetweenShoots;
			healthBehaviour = GetComponent<HealthBehaviour>();
			rifle = GetComponentInChildren<Rifle>();

			rifle.Shoot();
		}

		private void Update()
		{
			if (!healthBehaviour.IsAlive) return;

			if (timeUntilNextShoot > 0)
			{
				timeUntilNextShoot -= Time.deltaTime;
			}
			else
			{
				rifle.Shoot();
				timeUntilNextShoot = timeBetweenShoots;
			}
		}
	}
}