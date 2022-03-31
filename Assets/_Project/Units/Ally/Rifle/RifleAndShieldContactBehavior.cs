using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kamikaze.Units.Ally.Shield;

namespace Kamikaze.Units.Ally.Rifle
{
    public class RifleAndShieldContactBehavior : MonoBehaviour
    {
        private MoveOnLaneBehaviour moveOnLaneBehaviour;
        private float initialSpeed;
        

        public bool ShieldCanProtectRifle { get; set; }

        private void Awake()
        {
            moveOnLaneBehaviour = transform.GetComponent<MoveOnLaneBehaviour>();
        }


        // Start is called before the first frame update
        void Start()
        {
            initialSpeed = moveOnLaneBehaviour.MoveSpeed;
            
        }

        // Update is called once per frame
        void Update()
        {
            switch(ShieldCanProtectRifle)
            {
                case true:    
                    moveOnLaneBehaviour.MoveSpeed = 0f;
                    break;

                case false:
                    moveOnLaneBehaviour.MoveSpeed = initialSpeed;
                    break;

            }
        }
    }
}
