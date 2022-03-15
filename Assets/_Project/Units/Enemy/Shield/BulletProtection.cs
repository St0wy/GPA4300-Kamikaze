using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze
{
    public class BulletProtection : MonoBehaviour
    {
        private int protection = 10;
        [SerializeField] private GameObject shieldGo;

        void ReduceProtection()
        {
            protection--;
            if(protection <= 0)
            {
                Destroy(gameObject);
            }
        }
        void RaiseShield()
        {
            shieldGo.transform.localScale = new Vector3(0.20000000f, 0.9f, 0.9f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("AllyBullet"))
            {
                RaiseShield();
                ReduceProtection();
                Destroy(other.gameObject);
            }
        }

      

    }
}
