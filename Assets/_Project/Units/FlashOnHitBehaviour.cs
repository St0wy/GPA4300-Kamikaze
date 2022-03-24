using System;
using System.Collections;
using UnityEngine;

namespace Kamikaze.Units
{
	[RequireComponent(typeof(HealthBehaviour), typeof(MeshRenderer))]
	public class FlashOnHitBehaviour : MonoBehaviour
	{
		[Tooltip("Material that will be used when the player will flash.")]
		[SerializeField] private Material flashMaterial;

		[Tooltip("The time the flash will last in seconds.")]
		[SerializeField] private float flashTime = 0.3f;

		private HealthBehaviour healthBehaviour;
		private MeshRenderer meshRenderer;
		private Material baseMaterial;

		private void Awake()
		{
			healthBehaviour = GetComponent<HealthBehaviour>();
			healthBehaviour.OnHurt += _ => Flash();

			meshRenderer = GetComponent<MeshRenderer>();
			baseMaterial = meshRenderer.material;
		}

		private void Flash()
		{
			meshRenderer.material = flashMaterial;
			StartCoroutine(UnFlashCoroutine());
		}

		private IEnumerator UnFlashCoroutine()
		{
			yield return new WaitForSeconds(flashTime);
			meshRenderer.material = baseMaterial;
		}
	}
}