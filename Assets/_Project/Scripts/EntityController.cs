using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze
{
    public class EntityController : MonoBehaviour
    {
        public Vector3 endPosition;
        public Vector3 startPosition;
        public bool startMovement;

        private float desiredMovementDuration = 3f;
        private float elapsedTime;
        
        
        // Update is called once per frame
        void Update()
        {
            if(startMovement)
            {
                elapsedTime += Time.deltaTime;
                float percentageComplete = elapsedTime / desiredMovementDuration;

                transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
            }        
        }
    }
}
