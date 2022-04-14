using System.Collections;
using Kamikaze.Units.Enemy.Shield;
using UnityEngine;

namespace Kamikaze.Units
{
	[RequireComponent(typeof(HealthBehaviour))]
	public class FlashOnHitBehaviour : MonoBehaviour
	{
		[Tooltip("Material that will be used when the player will flash.")] [SerializeField]
		private Material flashMaterial;

		[Tooltip("The time the flash will last in seconds.")] [SerializeField]
		private float flashTime = 0.3f;

		[SerializeField] private MeshRenderer meshRenderer;

		private Material baseMaterial;
		private HealthBehaviour healthBehaviour;

		private void Awake()
		{
			healthBehaviour = GetComponent<HealthBehaviour>();
			healthBehaviour.OnHurt += OnHurt;

			if (meshRenderer == null) meshRenderer = GetComponent<MeshRenderer>();
			baseMaterial = meshRenderer.material;
		}

		private void OnDestroy()
		{
			healthBehaviour.OnHurt -= OnHurt;
		}

		private void OnHurt(int healthPoints)
		{
			Flash();
		}

		private void Flash()
		{
			var explosionProtection = GetComponent<ExplosionProtection>();
			if (explosionProtection != null)
			{
				if (explosionProtection.IsProtected) return;

				meshRenderer.material = flashMaterial;
				StartCoroutine(UnFlashCoroutine());
			}

			else
			{
				meshRenderer.material = flashMaterial;
				StartCoroutine(UnFlashCoroutine());
			}
		}


		private IEnumerator UnFlashCoroutine()
		{
			yield return new WaitForSeconds(flashTime);
			meshRenderer.material = baseMaterial;
		}
	}
}