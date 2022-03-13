using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze.Units
{
    public class FreezeAreaFreezingEnemy : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Shootable"))
            {
                MoveOnLaneBehaviour moveOnLaneBehaviour = other.GetComponent<MoveOnLaneBehaviour>();
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
