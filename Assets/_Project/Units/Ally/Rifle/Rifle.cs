using Kamikaze.Units.Ally.Bullet;
using UnityEngine;

namespace Kamikaze.Units.Ally.Rifle
{
    public class Rifle : MonoBehaviour
    {
        [SerializeField] private BulletBehavior bullet;
        [SerializeField] private Transform firePoint;

        public void Shoot()
        {
            Instantiate(bullet.gameObject, firePoint.position, Quaternion.identity);
        }
    }
}
