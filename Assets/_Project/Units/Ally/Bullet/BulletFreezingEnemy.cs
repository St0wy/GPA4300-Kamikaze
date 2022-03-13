using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze.Units
{
    public class BulletFreezingEnemy : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Shootable"))
            {
                BulletBehavior bulletBehavior = GetComponent<BulletBehavior>();
                if(bulletBehavior.IsFrozen)
                {
                    MoveOnLaneBehaviour moveOnLaneBehaviour = other.GetComponent<MoveOnLaneBehaviour>();
                    moveOnLaneBehaviour.MoveSpeed = 0.02f;
                    Destroy(gameObject);
                }       
            }
        }

    }
}
