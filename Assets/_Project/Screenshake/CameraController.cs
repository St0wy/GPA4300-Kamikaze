using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze.Screenshake
{
    public class CameraController : MonoBehaviour
    {    
        [SerializeField] private Transform target;
        private float startY;

        private void Start()
        {
            startY = transform.position.y;
        }

        private void Update()
        {
            if(target!=null)
            {
                transform.position = new Vector3(target.position.x, startY, transform.position.z);
            }
        }
    }
}
