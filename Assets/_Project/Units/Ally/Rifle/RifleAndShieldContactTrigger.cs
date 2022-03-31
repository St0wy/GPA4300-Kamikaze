using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kamikaze.Units.Ally.Shield;

namespace Kamikaze.Units.Ally.Rifle
{
    public class RifleAndShieldContactTrigger : MonoBehaviour
    {
        private RifleAndShieldContactBehavior rifleAndShieldContactBehavior;
        private ShieldTroopBehavior shieldTroopBehavior;

        private void Awake()
        {
            rifleAndShieldContactBehavior = GetComponent<RifleAndShieldContactBehavior>();

        }

        private void OnCollisionStay(Collision collision)
        {
            shieldTroopBehavior = collision.transform.GetComponent<ShieldTroopBehavior>();
            if (shieldTroopBehavior != null && shieldTroopBehavior.State == ShieldState.Shielding)
            {
                rifleAndShieldContactBehavior.RifleStayBehind = true;
                shieldTroopBehavior.RifleAndShieldContactBehavior = rifleAndShieldContactBehavior;
            }
        }
     
    }
}
