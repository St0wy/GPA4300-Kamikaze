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
            GameObject bulletGo = Instantiate(bullet.gameObject, firePoint.position, Quaternion.identity);

            BulletBehavior bulletBehavior = bulletGo.GetComponent<BulletBehavior>();
            if(bulletBehavior!=null)
            {
                bulletBehavior.Movement = Vector3.right;
            }

            Destroy(bulletGo, 4);
            

        }
    }
}
