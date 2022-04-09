using UnityEngine;

namespace Kamikaze.Screenshake
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField] private Transform target;

		private float startY;

		private void Start()
		{
			startY = transform.position.y;
		}

		private void Update()
		{
			if (target == null) return;

			Transform myTransform = transform;
			myTransform.position = new Vector3(target.position.x, startY, myTransform.position.z);
		}
	}
}