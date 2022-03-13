using UnityEngine;

namespace Kamikaze.Units.Ally.Bullet
{
    public class SynergyWithShield : MonoBehaviour
    {
        private void Start()
        {
            HasSynergy = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Shield"))
            {
                HasSynergy = true;
            }
        }

        public bool HasSynergy { get; set; }
    }
}
