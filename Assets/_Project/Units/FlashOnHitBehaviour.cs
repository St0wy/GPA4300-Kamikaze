using System.Collections;
using UnityEngine;
using Kamikaze.Units.Enemy.Shield;

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
			healthBehaviour.OnHurt += _ => Flash();

			if (meshRenderer == null)
			{
				meshRenderer = GetComponent<MeshRenderer>();
			}
			baseMaterial = meshRenderer.material;
		}

		private void Flash()
		{
			ExplosionProtection explosionProtection = GetComponent<ExplosionProtection>();
			if(explosionProtection!=null)
            {
				if(!explosionProtection.IsProtected)
                {
					meshRenderer.material = flashMaterial;
					StartCoroutine(UnFlashCoroutine());
				}
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