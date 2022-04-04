using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kamikaze.Units.Ally.Freezer;

namespace Kamikaze.Units.Enemy
{
    public class FreezeStuckIndicatorBehaviour : MonoBehaviour
    {
        [SerializeField] private float startScale;
        [SerializeField] private Transform component;
        private float animTargetScale;
        private float animSpeed;        
        private bool canStartAnim;
        

        private void Start()
        {
            component.localScale = new Vector3(startScale, startScale, startScale);
        }
        // Update is called once per frame
        void Update()
        {
            if(canStartAnim)
            {
                if (component.localScale.x < animTargetScale
                    && component.localScale.y < animTargetScale
                    && component.localScale.z < animTargetScale)
                {
                    component.localScale += new Vector3(Time.deltaTime * animSpeed, Time.deltaTime * animSpeed, Time.deltaTime * animSpeed);    
                }

                else
                {
                    canStartAnim = false;
                }
            }
           
        }

        public void StartAnim(float animTargetScale, float animSpeed)
        {
            this.animTargetScale = animTargetScale;
            this.animSpeed = animSpeed;
            canStartAnim = true;
        }
    }
}
