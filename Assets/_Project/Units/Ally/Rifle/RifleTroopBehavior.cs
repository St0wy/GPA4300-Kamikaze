using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze.Units
{
    public class RifleTroopBehavior : MonoBehaviour
    {
        private Rifle rifle;
        private float timeBetweenShoots = 0.2f; 
        [SerializeField] private float timeUntilNextShoot;

        private HealthBehaviour healthBehaviour;

        private void Awake()
        {
            timeUntilNextShoot = timeBetweenShoots;
            healthBehaviour = GetComponent<HealthBehaviour>();
            rifle = GetComponentInChildren<Rifle>();

            rifle.Shoot();
        }

        private void Update()
        {
            if(healthBehaviour.IsAlive)
            {
                if(timeUntilNextShoot > 0)
                {
                    timeUntilNextShoot -= Time.deltaTime;
                }

                else
                {
                    rifle.Shoot();
                    timeUntilNextShoot = timeBetweenShoots;
                }
            }
        }
    }
}
