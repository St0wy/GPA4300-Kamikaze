using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze
{
    public class FreezerAreaFreezingBullet : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Bullet"))
            {
                BulletBehavior bulletBehavior = other.GetComponent<BulletBehavior>();
                bulletBehavior.IsFrozen = true;
            }
        }
    }
}
