using UnityEngine;

namespace Kamikaze.Units.Enemy
{
	public class FreezeStuckIndicatorBehaviour : MonoBehaviour
	{
		[SerializeField] private float startScale;
		[SerializeField] private Transform component;

		private float animSpeed;
		private float animTargetScale;
		private bool canStartAnim;

		public bool IsSmallerThanTargetScale
		{
			get
			{
				Vector3 localScale = component.localScale;
				return localScale.x < animTargetScale
				       && localScale.y < animTargetScale
				       && localScale.z < animTargetScale;
			}
		}

		private void Start()
		{
			component.localScale = new Vector3(startScale, startScale, startScale);
		}

		private void Update()
		{
			if (!canStartAnim) return;

			if (IsSmallerThanTargetScale)
			{
				float newScale = Time.deltaTime * animSpeed;
				component.localScale += new Vector3(newScale, newScale, newScale);
			}
			else
			{
				canStartAnim = false;
			}
		}

		public void StartAnim(float targetScale, float speed)
		{
			animTargetScale = targetScale;
			animSpeed = speed;
			canStartAnim = true;
		}
	}
}