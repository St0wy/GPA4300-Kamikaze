using UnityEngine;

namespace Kamikaze.Units.Ally.Freezer
{
    public class FreezeAreaFreezingEnemy : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Shootable")) return;
            var moveOnLaneBehaviour = other.GetComponent<MoveOnLaneBehaviour>();

            if (moveOnLaneBehaviour != null)
            {
                moveOnLaneBehaviour.MoveSpeed = 0.02f;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Shootable"))
            {
                MoveOnLaneBehaviour moveOnLaneBehaviour = other.GetComponent<MoveOnLaneBehaviour>();
                moveOnLaneBehaviour.MoveSpeed = 0.1f;
            }
        }
    }
}