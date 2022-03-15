using UnityEngine;

namespace Kamikaze.Units.Enemy.Shield
{
    public class BulletProtection : MonoBehaviour
    {
        private int protection = 10;
        [SerializeField] private GameObject shieldGo;

        private void DecrementProtection()
        {
            protection--;
            if(protection <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void RaiseShield()
        {
            shieldGo.transform.localScale = new Vector3(0.20000000f, 0.9f, 0.9f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("AllyBullet")) return;
            RaiseShield();
            DecrementProtection();
            Destroy(other.gameObject);
        }

      

    }
}
