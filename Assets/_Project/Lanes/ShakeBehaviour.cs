using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze.Lanes
{
    public class ShakeBehaviour : MonoBehaviour
    {
        [SerializeField] private float shakePower;
        [SerializeField] private float shakeDuration;
        private float timeUntilEndOfShake;
        private Vector3 initialPos;
      
        
        // Start is called before the first frame update
        void Start()
        {
            initialPos = transform.position;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if(timeUntilEndOfShake > 0)
            {
                timeUntilEndOfShake -= Time.deltaTime;

                float xShake = -1f * shakePower;
                transform.position += new Vector3(xShake, 0, 0);
            }
            else
            {
                transform.position = initialPos;
            }
        }

        public void StartShake()
        {
            timeUntilEndOfShake = shakeDuration;      
        }
    }
}
