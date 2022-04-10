using Kamikaze.Units.Ally.Shield;
using UnityEngine;

namespace Kamikaze.Units.Ally.Bullet
{
	public class SynergyWithShield : MonoBehaviour
	{
		[SerializeField] private TrailRenderer trailRenderer;
		public bool HasSynergy { get; set; }

		private void Start()
		{
			HasSynergy = false;
		}

        private void Update()
        {
			if(HasSynergy)
            {
				trailRenderer.enabled = true;
				Debug.Log("synergy");
            }
            else
            {
				trailRenderer.enabled = false;
			}
        }

        private void OnTriggerEnter(Collider other)
		{
			if (!other.CompareTag("Ally")) return;

			var shieldTroopBehavior = other.GetComponent<ShieldTroopBehavior>();
			if (shieldTroopBehavior != null) HasSynergy = true;
		}
	}
}