using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze
{
    public class BulletBehavior : MonoBehaviour
    {
        private float speed = 800;
        private Rigidbody rb;
        private Vector3 movement;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            movement = Vector3.right;
            movement.Normalize();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            rb.velocity = movement * speed * Time.fixedDeltaTime;
        }
    }
}
