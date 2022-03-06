using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze
{
    public class UnitLaneDetection : MonoBehaviour
    {
        // EntityController entityController;

        private void Start()
        {
            // entityController = GetComponent<EntityController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Lane"))
            {
                // entityController.startPosition = other.GetComponent<Lane>().start;
                // entityController.endPosition = other.GetComponent<Lane>().end;
                // entityController.startMovement = true;
            }
        }
    }
}
