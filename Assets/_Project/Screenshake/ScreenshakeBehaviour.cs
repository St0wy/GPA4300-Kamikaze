using UnityEngine;
using Cinemachine;

namespace Kamikaze.Screenshake
{
	public class ScreenshakeBehaviour : MonoBehaviour
	{
		public static ScreenshakeBehaviour Instance { get; private set; }
		private CinemachineVirtualCamera cinemachineVirtualCamera;
		private float timeUntilEndOfScreenshake;

		private void Awake()
		{
			cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
		}

		private void Update()
		{
			if (!(timeUntilEndOfScreenshake > 0)) return;
			timeUntilEndOfScreenshake -= Time.deltaTime;

			if (!(timeUntilEndOfScreenshake <= 0f)) return;

			var cinemachineBasicMultiChannelPerlin =
				cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

			cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
		}

		public void StartScreenShake(float intensity, float duration)
		{
			var cinemachineBasicMultiChannelPerlin =
				cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

			cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
			timeUntilEndOfScreenshake = duration;
		}
	}
}