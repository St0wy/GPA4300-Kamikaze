using UnityEngine;

namespace Kamikaze
{
    public class EnemyLaneDetection : MonoBehaviour
    {
        // EntityController entityController;

        private void Start()
        {
            // entityController = GetComponent<EntityController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Lane"))
            {
                // entityController.startPosition = other.GetComponent<Lane>().end;
                // entityController.endPosition = other.GetComponent<Lane>().start;
                // entityController.startMovement = true;
            }
        }
    }
}
