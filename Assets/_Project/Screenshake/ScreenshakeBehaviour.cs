using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Kamikaze.Screenshake
{
    public class ScreenshakeBehaviour : MonoBehaviour
    {

        public static ScreenshakeBehaviour Instance { get; private set; }
        private CinemachineVirtualCamera cinemachineVirtualCamera;
        private float timeUntilEndOfScreenshake;

        // Start is called before the first frame update
        void Awake()
        {
            cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        private void Start()
        {
           
        }
        // Update is called once per frame
        void Update()
        {
            if(timeUntilEndOfScreenshake > 0)
            {
                timeUntilEndOfScreenshake -= Time.deltaTime;
                if(timeUntilEndOfScreenshake <= 0f)
                {
                    //end!
                    CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                    cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;

                }
            }
        }

        public void StartScreenShake(float intensity, float duration)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
            timeUntilEndOfScreenshake = duration;
        }
    }
}
