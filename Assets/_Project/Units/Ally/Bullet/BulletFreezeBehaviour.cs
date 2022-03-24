using Kamikaze.Units.Ally.Freezer;
using UnityEngine;

namespace Kamikaze.Units.Ally.Bullet
{
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(FreezeBehaviour))]
	public class BulletFreezeBehaviour : MonoBehaviour
	{
		[SerializeField] private Material freezeColor;

		private FreezeBehaviour freezeBehaviour;
		private MeshRenderer meshRenderer;
		private Material normalColor;

		private void Awake()
		{
			meshRenderer = GetComponent<MeshRenderer>();
			normalColor = meshRenderer.material;

			freezeBehaviour = GetComponent<FreezeBehaviour>();
			freezeBehaviour.OnFreeze += OnFreeze;
			freezeBehaviour.OnUnFreeze += OnUnFreeze;
		}

		private void OnFreeze()
		{
			meshRenderer.material = freezeColor;
		}

		private void OnUnFreeze()
		{
			meshRenderer.material = normalColor;
		}
	}
}