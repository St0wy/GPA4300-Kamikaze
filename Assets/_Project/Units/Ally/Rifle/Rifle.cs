using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze
{
    public class Rifle : MonoBehaviour
    {
        [SerializeField] private BulletBehavior bullet;
        [SerializeField] private Transform firePoint;

        public void Shoot()
        {
            GameObject bulletGo = Instantiate(bullet.gameObject, firePoint.position, Quaternion.identity);
        }
    }
}
